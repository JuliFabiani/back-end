using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace webAPIProject.Controllers
{
    
    [Route("api/clientes")]
    [ApiController]
    public class webAPIController : ControllerBase
    {     
        static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Nombre = "María Jesús", Apellido = "Farré Benet", Direccion = "Direccion1 1298" },
            new Cliente { Nombre = "Rebeca", Apellido = "Fuertes Castro", Direccion = "Direccion2 1544" },
            new Cliente { Nombre = "Régulo", Apellido = "del Checa", Direccion = "Direccion3 2526" },
            new Cliente { Nombre = "Florencio", Apellido = "Roma Marquez", Direccion = "Direccion4 3220" },
            new Cliente { Nombre = "Calixta", Apellido = "Montoya Collado", Direccion = "Direccion5 6285" },
            new Cliente { Nombre = "Flavio", Apellido = "de Pujadas", Direccion = "Direccion6 8344" },
            new Cliente { Nombre = "Marcela", Apellido = "Bou Grau", Direccion = "Direccion7 2347" },
            new Cliente { Nombre = "Juan Francisco", Apellido = "de Mariscal", Direccion = "Direccion8 9345" },
            new Cliente { Nombre = "Ciro", Apellido = "Rueda Manrique", Direccion = "Direccion9 2347" },
            new Cliente { Nombre = "Amalia", Apellido = "Gallardo Hervia", Direccion = "Direccion10 1498" }
        };

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            DelayRespuesta(); //DEBUG
            try
            {
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                String mensaje = "Error: " + ex.Message;
                return BadRequest(mensaje);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            DelayRespuesta(); //DEBUG
            try
            {
                var cliente = clientes[id];

                return Ok(cliente);
            }
            catch (Exception ex) //Mal acceso a 'clientes', fuera de rango.
            {
                String mensaje = "Error: " + ex.Message;

                return BadRequest(mensaje);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> Create(Cliente cliente)
        {
            DelayRespuesta(); //DEBUG
            try
            {
                clientes.Add(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                String mensaje = "Error: " + ex.Message;
                return BadRequest(mensaje);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> UpdateHero(Cliente req)
        {
            DelayRespuesta(); //DEBUG
            try
            {
                var index = clientes.FindIndex(c => c.Nombre == req.Nombre);
                //if (index == -1) return BadRequest("No se encuentra el cliente.");
                clientes[index] = req;
                return Ok();
            }
            catch (Exception ex)  {
                String mensaje = "Error: " + ex.Message;
                return BadRequest(mensaje);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            DelayRespuesta();
            try
            {
                var cliente = clientes[id];
                clientes.Remove(cliente);

                return Ok();
            }
            catch (Exception ex) //Mal acceso a 'clientes', fuera de rango.
            {
                String mensaje = "Error: " + ex.Message;

                return BadRequest(mensaje);
            }
        }

        private static void DelayRespuesta()
        {
            Random rand = new Random();
            int rand2 = rand.Next(1000)+1500;
            Thread.Sleep(rand2);
        }
     }
}
