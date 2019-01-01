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

    public class FilmeService : BaseService, IFilmeService
    {
        private readonly IMongoCollection<Filme> filmeRepository;

        public FilmeService(IConfiguration config) : base(config)
        {
            filmeRepository = base.DataBase.GetCollection<Filme>("Filmes");
        }

        public IEnumerable<FilmeDTO> GetAll()
        {
            var result = filmeRepository.Find(filter => true).ToEnumerable();

            foreach (var item in result)
            {
                yield return item.MapToDto();
            }
        }

        public FilmeDTO GetFilmeById(string Id)
        {
            var docId = new ObjectId(Id);

            var result = filmeRepository.Find(f => f.Id == docId).FirstOrDefault();

            return result.MapToDto();
        }

        public FilmeDTO Create(FilmeDTO filmeDto)
        {
            var filme = filmeDto.MapToModel();

            filmeRepository.InsertOne(filme);

            return filme.MapToDto();
        }

        public void Update(string Id, FilmeDTO filmeDto)
        {
            var filme = filmeDto.MapToModel(true);

            filmeRepository.ReplaceOne(f=> f.Id == filme.Id, filme);
        }

        public void Remove(string Id)
        {
            filmeRepository.DeleteOne(f => f.Id == new ObjectId(Id));
        }
    }
}
