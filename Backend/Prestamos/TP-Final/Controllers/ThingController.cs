using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using TP_Final.DataAccess;
using TP_Final.Domain;

namespace TP_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThingController : ControllerBase
    {
        private readonly PrestamosDbContext context;

        public ThingController(PrestamosDbContext context)
        {
            this.context = context;
        }

        public class ThingById
        {
            public int Id { get; set; }
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetAll")]
        public async Task<string> GetAll()
        {
            DataThing dataThing = new DataThing(context);
            var things = await dataThing.GetAllThings();
            return JsonSerializer.Serialize(things);
        }

        [HttpPost]
        [Authorize(Roles = ("user"))]
        [Route("Add")]
        public async Task<string> Add([FromBody] Thing thing)
        {
            DataThing dataThing = new DataThing(context);
            var addedThing = await dataThing.Add(thing);

            return JsonSerializer.Serialize(addedThing);
        }

        [HttpPut]
        [Authorize(Roles = ("user"))]
        [Route("Update/{id}")]
        public async Task<string> Update([FromBody] Thing thing)
        {
            Thing thingToUpdate = new Thing();
            thingToUpdate.Id = thing.Id;
            thingToUpdate.Description = thing.Description;
            thingToUpdate.IdCategory = thing.IdCategory;
            thingToUpdate.PersonDni = thing.PersonDni;


            DataThing dataThing = new DataThing(context);
            var updatedThing = await dataThing.Update(thing);
            if (updatedThing == null)
            {
                throw new ValidationException("Esa cosa no existe");
            }
            return JsonSerializer.Serialize(updatedThing);
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetByDni")]
        public async Task<string> GetThingsByDni()
        {
            var user = HttpContext.User;
            var dniClaim = user.FindFirst("Dni");
            var userDni = int.Parse(dniClaim.Value);
            DataThing dataThing = new DataThing(context);
            var things = await dataThing.GetByDni(userDni);
            return JsonSerializer.Serialize(things);
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetThingById/{id}")]
        public async Task<string> GetThingById([FromRoute] int id)
        {
            
            DataThing dataThing = new DataThing(context);
            var thing = await dataThing.GetThingById(id);
            
            Console.WriteLine(JsonSerializer.Serialize(thing));
            return JsonSerializer.Serialize(thing);
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetAvailablesByDni/{dni}")]
        public async Task<string> GetAvailablesByDni([FromRoute] int dni)
        {
            DataThing dataThing = new DataThing(context);
            var things = await dataThing.GetAvailablesByDni(dni);
            Console.WriteLine(things);
            return JsonSerializer.Serialize(things);
        }

        [HttpGet]
        [Authorize(Roles = ("user"))]
        [Route("GetBorrowedByDni/{dni}")]
        public async Task<string> GetBorrowedByDni([FromRoute] int dni)
        {
            DataThing dataThing = new DataThing(context);
            var things = await dataThing.GetBorrowedByDni(dni);
            Console.WriteLine(things);
            return JsonSerializer.Serialize(things);
        }
    }
}