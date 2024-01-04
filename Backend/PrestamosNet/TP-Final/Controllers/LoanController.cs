using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.Json;
using TP_Final.DataAccess;
using TP_Final.Domain;

namespace TP_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly PrestamosDbContext context;

        public LoanController(PrestamosDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetByDni")]
        public async Task<string> GetByDni(int dni)
        {
            var dniUser = HttpContext.User.FindFirst("Dni");
            var userDni = int.Parse(dniUser.Value);

            DataLoan dataLoan = new DataLoan(context);
            var loans = await dataLoan.GetByDni(userDni);
            if (loans == null)
            {
                throw new ValidationException("La persona no tiene prestamos");
            }
            else return JsonSerializer.Serialize(loans);
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetByThingId/{id}")]
        public async Task<string> GetByThingId(int id)
        {
            DataLoan dataLoan = new DataLoan(context);
            var thingLoan = await dataLoan.GetByThingId(id);
            return JsonSerializer.Serialize(thingLoan);
        }

        [HttpPost]
        [Authorize(Roles = ("user"))]
        [Route("Add")]
        public async Task<string> Add([FromBody] Loan loan)
        {
            
            Console.WriteLine("ENTRA ?????????: ",loan);
            DataLoan dataLoan = new DataLoan(context);
            var addedLoan = await dataLoan.Add(loan);
            return JsonSerializer.Serialize(addedLoan);
        }

        [HttpPut]
        [Authorize(Roles = ("user"))]
        [Route("Return/{id}")]
        public async Task<string> Return([FromRoute] int id)
        {
            Console.WriteLine(id);
            DataLoan dataLoan = new DataLoan(context);
            var returnedLoan = await dataLoan.Return(id);
            return JsonSerializer.Serialize(returnedLoan);
        }

        
    }
}