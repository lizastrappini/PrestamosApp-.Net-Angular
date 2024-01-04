
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Final.Domain;

namespace TP_Final.DataAccess
{

    public class DataLoan : DbContext

    {
        private readonly PrestamosDbContext context;

        public DataLoan(PrestamosDbContext context)
        {
            this.context = context;
        }

        public async Task<Loan[]> GetByDni(int dni)
        {
            var loans = await context.Loan.Where(x => x.DniPerson == dni).ToListAsync();
            return loans.ToArray();
        }

        public async Task<Loan> Add(Loan loan)
        {
                context.Loan.Add(loan);
                await this.context.SaveChangesAsync();
                return loan;  
            
        }

        public async Task<int?> Return(int id)
        {
            var returnedLoan = await context.Loan.Where(l => l.IdThing == id && l.Status=="prestado").FirstOrDefaultAsync();
            if (returnedLoan == null)
            {
                return null;
            }
            else
            {
                returnedLoan.Status = "Devuelto";
                await this.context.SaveChangesAsync();
                return returnedLoan.Id; 
            }
        }

        public async Task<Loan> GetByThingId(int id)
        {
            var loan = await context.Loan.Where(l => l.IdThing == id && l.Status=="prestado").FirstOrDefaultAsync();
            return loan;
        }
        }
}
