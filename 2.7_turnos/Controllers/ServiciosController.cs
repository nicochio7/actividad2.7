using Microsoft.AspNetCore.Mvc;
using turnos_back.Models;
using turnos_back.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2._7_turnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiceServicio _service;

        public ServiciosController(IServiceServicio serviceServicio)
        {
            _service = serviceServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return  Ok(await _service.GetAll());
            }
            catch(Exception)
            {
                 return StatusCode(500 , "Error al obtener los servicios");
            }
            
        }

        // GET api/<ServiciosController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var devuelto =await _service.GetById(id);
                if (devuelto != null)
                {
                    return Ok(devuelto);
                }
                return NotFound("no encotre nada pelotudito");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al obtener los servicios");
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                _service.Add(servicio);
                return Ok("Servicio agregado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al agregar el servicio");
            }   
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TServicio servicio)
        {
            try
            {
                await _service.Update(servicio);
                return Ok("Servicio actualizado correctamente");   
            }
            catch (Exception)
            {
                return StatusCode(500, "Error al actualizar el servicio");  
            }
             
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Servicio eliminado correctamente");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error al eliminar el servicio");
            }
        }
    }
}
