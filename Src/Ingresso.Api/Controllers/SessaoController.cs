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
        public async Task<IEnumerable<SessaoDTO>> Get()
        {
            return await sessaoService.GetAllAsync().ConfigureAwait(false);
        }

        // GET: api/sessao/5
        [HttpGet("{id}", Name = "GetSessao")]
        public async Task<ActionResult<SessaoDTO>> Get(string id)
        {
            var sessao = await sessaoService.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            return sessao;
        }

        // POST: api/sessao
        [HttpPost]
        public async Task<ActionResult<SessaoDTO>> PostAsync([FromBody] SessaoDTO sessao)
        {
            var createdsessao = await sessaoService.CreateAsync(sessao);

            return CreatedAtRoute("Get", new { createdsessao.Id }, createdsessao);
        }

        // PUT: api/sessao/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(string id, [FromBody] SessaoDTO sessaoToUpdate)
        {
            var sessao = await sessaoService.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            await sessaoService.UpdateAsync(id, sessaoToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var sessao = await sessaoService.GetSessaoByIdAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            await sessaoService.RemoveAsync(id);

            return NoContent();
        }
    }
}
