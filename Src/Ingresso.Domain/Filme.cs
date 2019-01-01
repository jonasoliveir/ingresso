namespace Ingresso.Domain
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Filme
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("InicioEmCartaz")]
        public DateTime InicioEmCartaz { get; set; }

        [BsonElement("FimEmCartaz")]
        public DateTime FimEmCartaz { get; set; }

        //public List<SessaoDTO> Sessoes { get; set; }

        //public List<SalaDTO> Salas { get; set; }
    }
}
