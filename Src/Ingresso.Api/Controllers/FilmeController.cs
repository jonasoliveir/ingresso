using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ingresso.Api.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        // GET: api/Filme
        [HttpGet]
        public IEnumerable<FilmeDTO> Get()
        {
            return new List<FilmeDTO> { new FilmeDTO { InicioEmCartaz = DateTime.Now,
                FimEmCartaz = DateTime.Now.AddDays(45),
                Nome = "Meu filme louco",
                Salas = new List<SalaDTO>
                {
                    new SalaDTO { Nome = "Sala 1", Cinema = "Kinoplex" }
                },
                Sessoes = new List<SessaoDTO>{
                        new SessaoDTO { Data = DateTime.Now.AddDays(1),
                            QtLugar = 100
                        }
                }
            }};
        }

        // GET: api/Filme/5
        [HttpGet("{id}", Name = "Get")]
        public FilmeDTO Get(int id)
        {
            return new FilmeDTO();
        }

        // POST: api/Filme
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Filme/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
