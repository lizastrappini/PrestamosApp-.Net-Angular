using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TP_Final.Domain;

namespace TP_Final.DataAccess
{
    public class DataThing : DbContext
    {
        private readonly PrestamosDbContext context;

        public DataThing(PrestamosDbContext context)
        {
            this.context = context;
        }

        public async Task<Thing[]> GetAllThings()
        {
            var things = await context.Thing.ToListAsync();
            return things.ToArray();
        }

        public async Task<Thing> Add(Thing thingToAdd)
        {
            context.Thing.Add(thingToAdd);
            await this.context.SaveChangesAsync();
            return thingToAdd;
        }

        public async Task<Thing> Update(Thing thingToUpdate)
        {
            var updatedThing = await context.Thing.Where(t => t.Id == thingToUpdate.Id).FirstOrDefaultAsync();


            if (updatedThing == null)
            {
                return null;
            }
            else
            {
                context.Entry(updatedThing).CurrentValues.SetValues(thingToUpdate);
                await this.context.SaveChangesAsync();
                return updatedThing;
            }
        }
        public async Task<Thing[]> GetByDni(int dni)
        {
            var things = await context.Thing.Where(t => t.PersonDni == dni).ToListAsync();
            return things.ToArray();
        }

        public async Task<Thing> GetByDescription(string description)
        {
            var thing = await context.Thing.Where(t => t.Description == description).FirstOrDefaultAsync();
            if (thing == null)
            {
                return null;
            }
            else
            {
                return thing;
            }
        }

        public async Task<Thing> GetThingById(int id)
        {
            var thing = await context.Thing.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (thing == null)
            {
                return null;
            }
            else
            {
                return thing;
            }
        }
        
        public async Task<Thing[]> GetAvailablesByDni(int dni)
        {
            var sql = @" SELECT t.*
                        FROM Thing t
                        WHERE t.PersonDni = @dni
                        AND (NOT EXISTS (SELECT 1 FROM Loan l WHERE l.IdThing = t.Id) OR
                        EXISTS (SELECT 1 FROM Loan l WHERE l.DniPerson = t.PersonDni AND l.Status = 'devuelto')) ";

            var thingsWithoutLoans = await context.Thing
                .FromSqlRaw(sql, new SqlParameter("@dni", dni))
                .ToListAsync();

            return thingsWithoutLoans.ToArray();
        }

        public async Task<Thing[]> GetBorrowedByDni(int dni)
        {
            var sql = @"
                    SELECT t.*
                    FROM Thing t
                    WHERE t.PersonDni = @dni
                    AND EXISTS (SELECT 1 FROM Loan l WHERE l.IdThing = t.Id AND l.Status = 'prestado')";

            var thingsWithActiveLoans = await context.Thing
                .FromSqlRaw(sql, new SqlParameter("@dni", dni))
                .ToListAsync();

            return thingsWithActiveLoans.ToArray();
        }
    }
    
}
