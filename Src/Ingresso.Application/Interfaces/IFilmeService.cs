using System.Collections.Generic;
using Application.DTO;

namespace Ingresso.Application.Interfaces
{
    public interface IFilmeService
    {
        IEnumerable<FilmeDTO> GetAll();

        FilmeDTO GetFilmeById(string Id);

        FilmeDTO Create(FilmeDTO filmeDto);

        void Update(string Id, FilmeDTO filmeDto);

        void Remove(string Id);
    }
}