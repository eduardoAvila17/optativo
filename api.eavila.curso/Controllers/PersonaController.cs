using api.eavila.curso.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace api.eavila.curso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PersonaController : Controller
    {
        private PersonaService personaService;

        private IConfiguration configuration;

        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaService = new PersonaService(configuration.GetConnectionString("postgresDB"));

        }

        [HttpGet("ListarPersonas")]
        public ActionResult<List<PersonaModel>> ListarPersonas()
        {
            var resultado = personaService.listarPersona();
            return Ok(resultado);
        }


        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id)
        {
            var resultado = personaService.consultarPersona(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insertarPersona(PersonaModel modelo)
        {
            var resultado = this.personaService.insertarPersona(new infraestructura.Model.PersonaModel
            {
                Id = modelo.Id , 
                Nombre = modelo.Nombre ,
                Apellido = modelo.Apellido ,
                Edad = modelo.Edad ,
                Email = modelo.Email ,
                Telefono = modelo.Telefono

            });
            
            return Ok(resultado);
        }

        [HttpPut("ModificarPersona/{id}")]
        public ActionResult<string> modificarPersona(PersonaModel modelo , int id )
        {
            if (personaService.consultarPersona(id) != null)
            {
                var resultado = this.personaService.modificarPersona(new infraestructura.Model.PersonaModel
                {
                    Nombre = modelo.Nombre,
                    Apellido = modelo.Apellido,
                    Edad = modelo.Edad,
                    Email = modelo.Email,
                    Telefono = modelo.Telefono

                }, id);

                return Ok(resultado);
            }
            else
                return NotFound("Persona no Existe!");
           
        }

        [HttpDelete("EliminarPersona/{id}")]
        public ActionResult<string> eliminarPersona( int id)
        {
            var resultado = this.personaService.eliminarPersona(id);
            return Ok(resultado);
        }

    }
}
