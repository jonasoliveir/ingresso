﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
    }
}
