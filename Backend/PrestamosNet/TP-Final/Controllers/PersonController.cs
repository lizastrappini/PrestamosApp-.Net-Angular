using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TP_Final.DataAccess;
using TP_Final.Domain;

namespace TP_Final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PrestamosDbContext context;
        private readonly IConfiguration _config;

        public PersonController(PrestamosDbContext context, IConfiguration config)
        {
            _config = config;
            this.context = context;
        }
        public class UserLoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        private Task<Person> Authenticate(string email, string password)
        {
            DataPerson dataPerson = new DataPerson(context);
            return dataPerson.LoginPerson(email, password);
        }
        private string Generate(Person user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
 
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name, user.LastName, "admin"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "user"),
                new Claim("Dni", user.Dni.ToString())


            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userToLogIn)
        {

            var user = await Authenticate(userToLogIn.Email, userToLogIn.Password);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(new { Token = token, User = user.Dni });
            }

            else
            {
                return Unauthorized(new
                {
                    status = "error",
                    message = "Verifica tu nombre de usuario y contraseña."
                });
            }
        }

        

        [HttpPost]
        [Route("Register")]
        public async Task<string> Register([FromBody] Person userToRegister)
        {
            //if (HttpContext.User == null) { 
            
            DataPerson dataPerson = new DataPerson(context);
            var registeredUser = await dataPerson.Register(userToRegister);
            if (registeredUser == null)
            {
                throw new ValidationException("Esa persona ya existe");
            }
            else return JsonSerializer.Serialize(registeredUser);

            // } else return Redirect("");
        }

        [HttpGet]
        [Route("People")]
        public async Task<string> GetPeople()
        {
            DataPerson dataPerson = new DataPerson(context);
            var people = await dataPerson.GetAll();
            return JsonSerializer.Serialize(people);
        }

        [HttpDelete]
        [Authorize(Roles = ("user"))]
        [Route("Delete/{dni}")]
        public async Task<string> DeletePerson(int dni)
        {

            DataPerson dataPerson = new DataPerson(context);
            var person = await dataPerson.Delete(dni);
            if(person == null)
            {
                throw new ValidationException("Esa persona no existe");
            }
            else return JsonSerializer.Serialize(person);
           
        }

        [HttpPut]
        [Authorize(Roles = ("user"))]
        [Route("Update/{dni}")]
        public async Task<string> UpdatePerson([FromBody] Person userToUpdate)
        {
            DataPerson dataPerson = new DataPerson(context);

            var updatedUser = await dataPerson.Update(userToUpdate);
            if (updatedUser == null)
            {
                throw new ValidationException("Esa persona no existe");
            }else return JsonSerializer.Serialize(updatedUser);
            
        }
    }
}
