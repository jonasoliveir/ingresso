using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingresso.Domain
{
    public class Sessao
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("Data")]
        public DateTime Data { get; set; }

        [BsonElement("QtLugar")]
        public int QtLugar { get; set; }

        [BsonElement("Valor")]
        public decimal Valor { get; set; }

        public MongoDBRef FilmeId { get; set; }

        public string Legenda { get; set; }

        [BsonElement]
        public IEnumerable<Horario> Horarios { get; set; }

    }
}
