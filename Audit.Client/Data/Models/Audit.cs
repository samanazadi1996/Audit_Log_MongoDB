using Audit.Client.Data.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Audit.Client.Data.Models
{
    public class Audit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public ICollection<string> Messages { get; set; }
        public AuditLevel Level { get; set; }
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
    }
}
