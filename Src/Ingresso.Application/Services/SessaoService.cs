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

    public class SessaoService : BaseService, ISessaoService
    {
        private readonly IMongoCollection<Sessao> sessaoRepository;

        public SessaoService(IConfiguration config) : base(config)
        {
            sessaoRepository = base.DataBase.GetCollection<Sessao>("Sessoes");
        }

        public IEnumerable<SessaoDTO> GetAll()
        {
            var result = sessaoRepository.Find(filter => true).ToEnumerable();

            foreach (var item in result)
            {
                yield return item.MapToDto();
            }
        }

        public SessaoDTO GetSessaoById(string Id)
        {
            var docId = new ObjectId(Id);

            var result = sessaoRepository.Find(f => f.Id == docId).FirstOrDefault();

            return result.MapToDto();
        }

        public SessaoDTO Create(SessaoDTO sessaoDto)
        {
            var sessao = sessaoDto.MapToModel();

            sessaoRepository.InsertOne(sessao);

            return sessao.MapToDto();
        }

        public void Update(string Id, SessaoDTO sessaoDto)
        {
            var sessao = sessaoDto.MapToModel(true);

            sessaoRepository.ReplaceOne(f => f.Id == sessao.Id, sessao);
        }

        public void Remove(string Id)
        {
            sessaoRepository.DeleteOne(f => f.Id == new ObjectId(Id));
        }
    }
}
