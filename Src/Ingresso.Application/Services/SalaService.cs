namespace Ingresso.Application.Services
{
    using global::Application.DTO;
    using Ingresso.Application.Extensions;
    using Ingresso.Application.Interfaces;
    using Ingresso.Domain;
    using Microsoft.Extensions.Configuration;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Collections.Generic;

    public class SalaService : BaseService, ISalaService
    {
        private readonly IMongoCollection<Sala> salaRepository;

        public SalaService(IConfiguration config) : base(config)
        {
            salaRepository = base.DataBase.GetCollection<Sala>("Salas");
        }
        
        public SalaDTO GetSalaById(string Id)
        {
            var docId = new ObjectId(Id);

            var result = salaRepository.Find(f => f.Id == docId).FirstOrDefault();

            return result.MapToDto();
        }

        public IEnumerable<SalaDTO> GetAll()
        {
            var result = salaRepository.Find(filter => true).ToEnumerable();

            foreach (var item in result)
            {
                yield return item.MapToDto();
            }
        }

        public SalaDTO Create(SalaDTO salaDto)
        {
            var sala = salaDto.MapToModel();

            salaRepository.InsertOne(sala);

            return sala.MapToDto();
        }


        public void Update(string Id, SalaDTO salaDto)
        {
            var sala = salaDto.MapToModel(true);

            salaRepository.ReplaceOne(f => f.Id == sala.Id, sala);
        }

        public void Remove(string Id)
        {
            salaRepository.DeleteOne(f => f.Id == new ObjectId(Id));
        }
    }
}
