using System.Collections.Generic;
using Application.DTO;

namespace Ingresso.Application.Interfaces
{
    public interface ISessaoService
    {
        IEnumerable<SessaoDTO> GetAll();

        SessaoDTO GetSessaoById(string Id);

        SessaoDTO Create(SessaoDTO sessaoDto);

        void Update(string Id, SessaoDTO sessaoDto);

        void Remove(string Id);
    }
}
