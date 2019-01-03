using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Ingresso.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [Route("api/salas")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService salaService;

        public SalaController(ISalaService salaService)
        {
            this.salaService = salaService;
        }

        // GET: api/sala
        [HttpGet]
        public IEnumerable<SalaDTO> Get()
        {
            return salaService.GetAll();
        }

        // GET: api/sala/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<SalaDTO> Get(string id)
        {
            var sala = salaService.GetSalaById(id);

            if (sala == null)
            {
                return NotFound();
            }

            return sala;
        }

        // POST: api/sala
        [HttpPost]
        public ActionResult<SalaDTO> Post([FromBody] SalaDTO sala)
        {
            var createdsala = salaService.Create(sala);

            return CreatedAtRoute("Get", new { createdsala.Id }, createdsala);
        }

        // PUT: api/sala/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] SalaDTO salaToUpdate)
        {
            var sala = salaService.GetSalaById(id);

            if (sala == null)
            {
                return NotFound();
            }

            salaService.Update(id, salaToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var sala = salaService.GetSalaById(id);

            if (sala == null)
            {
                return NotFound();
            }

            salaService.Remove(id);

            return NoContent();
        }
    }
}
