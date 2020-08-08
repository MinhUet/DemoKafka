using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Entity.Entities
{
    [Serializable]
    public class OutboxEmail : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string EmailID { get; set; }
        public string ApplicationCode { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailSenderName { get; set; }
        public string EmailSenderAddress { get; set; }
        public int RetryTime { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Array)]
        public List<Recipient> Recipients { get; set; }
    }
}
