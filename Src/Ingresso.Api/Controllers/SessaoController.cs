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
    [Route("api/sessoes")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService sessaoService;

        public SessaoController(ISessaoService sessaoService)
        {
            this.sessaoService = sessaoService;
        }

        // GET: api/sessao
        [HttpGet]
        public IEnumerable<SessaoDTO> Get()
        {
            return sessaoService.GetAll();
        }

        // GET: api/sessao/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<SessaoDTO> Get(string id)
        {
            var sessao = sessaoService.GetSessaoById(id);

            if (sessao == null)
            {
                return NotFound();
            }

            return sessao;
        }

        // POST: api/sessao
        [HttpPost]
        public ActionResult<SessaoDTO> Post([FromBody] SessaoDTO sessao)
        {
            var createdsessao = sessaoService.Create(sessao);

            return CreatedAtRoute("Get", new { createdsessao.Id }, createdsessao);
        }

        // PUT: api/sessao/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] SessaoDTO sessaoToUpdate)
        {
            var sessao = sessaoService.GetSessaoById(id);

            if (sessao == null)
            {
                return NotFound();
            }

            sessaoService.Update(id, sessaoToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var sessao = sessaoService.GetSessaoById(id);

            if (sessao == null)
            {
                return NotFound();
            }

            sessaoService.Remove(id);

            return NoContent();
        }
    }
}
