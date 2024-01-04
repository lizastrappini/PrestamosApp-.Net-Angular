using Microsoft.EntityFrameworkCore;
using TP_Final.Domain;

namespace TP_Final.DataAccess
{
    public class DataPerson : DbContext
    {
        private readonly PrestamosDbContext context;

        public DataPerson(PrestamosDbContext context)
        {
            this.context = context;
        }

        public async Task<Person> LoginPerson(string email, string password)
        {
            var user = await context.Person.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<Person> Register(Person userToRegister)
        {
           
            var registeredUser = await context.Person.Where(p => p.Email == userToRegister.Email || p.Dni == userToRegister.Dni).FirstOrDefaultAsync();
            if (registeredUser == null)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userToRegister.Password);
                userToRegister.Password = hashedPassword;
                context.Person.Add(userToRegister);
                await this.context.SaveChangesAsync();
                return userToRegister;
            }else return null;
        }

        public async Task<Person[]> GetAll()
        {
            var people = await context.Person.ToListAsync();
            return people.ToArray();
        }

        public async Task<Person> Delete(int dni)
        {
            var person = await context.Person.FirstOrDefaultAsync(x => x.Dni == dni);
            if (person == null)
            {
                return null;
            }
            else
            {
                context.Person.Remove(person);
                await this.context.SaveChangesAsync();
                return person;
            }
        }

        public async Task<Person> Update(Person userToUpdate)
        {
           var updatedPerson = await context.Person.Where(p => p.Dni == userToUpdate.Dni).FirstOrDefaultAsync();
            

            if (updatedPerson == null)
            {
                return null;
            }
            else
            {
                context.Entry(updatedPerson).CurrentValues.SetValues(userToUpdate);
                await this.context.SaveChangesAsync();
                return updatedPerson;
            }
        }

        public async Task<Person> GetByDni(int dni)
        {
            var person = await context.Person.FirstOrDefaultAsync(x => x.Dni == dni);
            if (person == null)
            {
                return null;
            }else return person;
        }
    }
}
