using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Entity.Entities
{
    public class EmailTopic : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public string EmailTopicID { get; set; }
        [BsonRequired]
        [BsonElement("EmailTopicName")]
        public string EmailTopicName { get; set; }

    }
}
