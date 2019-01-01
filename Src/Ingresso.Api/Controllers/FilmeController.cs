

namespace Ingresso.Api.Controllers
{
    using global::Application.DTO;
    using Ingresso.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            this.filmeService = filmeService;
        }

        // GET: api/Filme
        [HttpGet]
        public IEnumerable<FilmeDTO> Get()
        {
            return filmeService.GetAll();
        }

        // GET: api/Filme/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<FilmeDTO> Get(string id)
        {
            var filme = filmeService.GetFilmeById(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // POST: api/Filme
        [HttpPost]
        public ActionResult<FilmeDTO> Post([FromBody] FilmeDTO filme)
        {
            var createdFilme = filmeService.Create(filme);

            return CreatedAtRoute("Get", new { createdFilme.Id }, createdFilme);
        }

        // PUT: api/Filme/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FilmeDTO filmeToUpdate)
        {
            var filme = filmeService.GetFilmeById(id);

            if (filme == null)
            {
                return NotFound();
            }

            filmeService.Update(id, filmeToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var filme = filmeService.GetFilmeById(id);

            if (filme == null)
            {
                return NotFound();
            }

            filmeService.Remove(id);

            return NoContent();
        }
    }
}
