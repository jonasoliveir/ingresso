namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Data.Interfaces;
    using Ingresso.Domain;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SessaoService : ISessaoService
    {
        private readonly ISessaoRepository sessaoRepository;

        public SessaoService(ISessaoRepository sessaoRepository)
        {
            this.sessaoRepository = sessaoRepository;
        }

        public async Task<IEnumerable<SessaoDTO>> GetAllAsync()
        {
            var result = await sessaoRepository.GetAllSessoesAsync().ConfigureAwait(false);

            var mappedFilmes = new List<SessaoDTO>();

            foreach (var item in result)
            {
                mappedFilmes.Add(item.MapToDto());
            }

            return mappedFilmes;
        }

        public async Task<SessaoDTO> GetSessaoByIdAsync(string Id)
        {
            var result = await sessaoRepository.GetSessaoAsync(Id);

            return result.MapToDto();
        }

        public async Task<SessaoDTO> CreateAsync(SessaoDTO SessaoDTO)
        {
            var sessao = SessaoDTO.MapToModel();

            await sessaoRepository.AddSessaoAsync(sessao);

            return sessao.MapToDto();
        }

        public async Task<bool> UpdateAsync(string Id, SessaoDTO SessaoDTO)
        {
            var currentSessao = await sessaoRepository.GetSessaoAsync(Id);

            currentSessao.MapToNewValues(SessaoDTO);

            return await sessaoRepository.UpdateSessaoAsync(Id, currentSessao);
        }

        public async Task<bool> RemoveAsync(string Id)
        {
            return await sessaoRepository.RemoveSessaoAsync(Id);
        }
    }
}
