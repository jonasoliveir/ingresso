using System.Collections.Generic;
using Application.DTO;

namespace Ingresso.Application.Interfaces
{
    public interface ISalaService
    {
        IEnumerable<SalaDTO> GetAll();

        SalaDTO GetSalaById(string Id);

        SalaDTO Create(SalaDTO salaDto);

        void Update(string Id, SalaDTO salaDto);

        void Remove(string Id);
    }
}