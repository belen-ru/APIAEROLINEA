using APIAEROLINEA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIAEROLINEA.Repositories;
using APIAEROLINEA.DTOs;
using System.Timers;
using System.Threading;

namespace APIAEROLINEA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineaController : ControllerBase
    {
        private readonly sistem21_aerolinaCBContext context;
        Repository<Aeorolinea> repository;


        public AerolineaController(sistem21_aerolinaCBContext context)
        {
            this.context = context;
            this.repository = new(context);
       
        }

        [HttpGet]
        public IActionResult Get()
        {

            var data = repository.Get().OrderBy(x => x.Destination);

            return Ok(data.Select(x => new AerolineaDTO
            {
                Id = x.Id,
                Time = x.Time,
                Destination = x.Destination,
                Flight = x.Flight,
                Gate = x.Gate,
                Remarks = x.Remarks
            }));
        }
    

        [HttpPost]
        public IActionResult Post(AerolineaDTO aerolinea)
        {

            
            
            if (aerolinea == null)
            {
                return BadRequest("Debe especificar la aerolinea a agregar.");
            }
            if (string.IsNullOrWhiteSpace(aerolinea.Destination))
            {
                return BadRequest("Debe escribir un destino .");
            }
            if (string.IsNullOrWhiteSpace(aerolinea.Flight))
            {
                return BadRequest("Debe escribir el vuelo.");
            }
            if (aerolinea.Gate <= 0)
            {
                return BadRequest("Escriba el numero de puerta");
            }
            if (aerolinea.Gate > 100)
            {
                return BadRequest("Escriba un numero del 1 al 100");
            }

            Aeorolinea entidad = new()
            {
                Time = aerolinea.Time,
                Destination = aerolinea.Destination,
                Flight = aerolinea.Flight,
                Gate = aerolinea.Gate,
                Remarks = aerolinea.Remarks,
                Count = aerolinea.Count
                
            };
            repository.Insert(entidad);

            return Ok();

        }

      

        [HttpPut]
        public IActionResult Put(AerolineaDTO aerolinea)
        {
          
            if (aerolinea == null)
            {
                return BadRequest("Debe especificar la aerolinea a agregar.");
            }
            if (string.IsNullOrWhiteSpace(aerolinea.Destination))
            {
                return BadRequest("Especifique el destino del vuelo.");
            }
            if (string.IsNullOrWhiteSpace(aerolinea.Flight))
            {
                return BadRequest("Especifique el vuelo.");
            }
            if (aerolinea.Gate <= 0)
            {
                return BadRequest("Especifique el número de puerta");
            }
            if (aerolinea.Gate > 100)
            {
                return BadRequest("Escriba un número del 1 al 100");
            }
            var entidad = repository.Get(aerolinea.Id);

            if (entidad == null)
            {
                NotFound("No existe");
            }

            if (entidad != null)
            {
                entidad.Time = aerolinea.Time;
                entidad.Destination = aerolinea.Destination;
                entidad.Flight = aerolinea.Flight;
                entidad.Gate = aerolinea.Gate;
                entidad.Remarks = aerolinea.Remarks;
                repository.Update(entidad);
            }
            return Ok();
        }
    

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


            var entidad = repository.Get(id);
            if (entidad == null)
            {
                return NotFound("No se encontro un vuelo");
            }
            if (entidad.Remarks =="CANCELADO")
            {
                repository.Delete(entidad);

            }

            repository.Delete(entidad);
            return Ok();
        }
        [HttpGet("Cancelados")]
        public IActionResult GetC()
        {
            

            var data = repository.Get().Where(x => x.Remarks=="CANCELADO");


            return Ok(data.Select(x => new AerolineaDTO
            {
                Id = x.Id,
                Time = x.Time,
                Destination = x.Destination,
                Flight = x.Flight,
                Gate = x.Gate,
                Remarks = x.Remarks

            }));

            
        }

        [HttpDelete("Cancelados")]
        public IActionResult Deletes()
        {
            var data = repository.Get().Where(x => x.Remarks == "CANCELADO").Select(x => x).FirstOrDefault();
            if (data == null)
            {
                return NotFound();
            }
            repository.Delete(data);
            return Ok();
        }



    }
}
