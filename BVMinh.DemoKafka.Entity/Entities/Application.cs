using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BVMinh.DemoKafka.Entity.Entities
{
    public class Application : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ApplicationID { get; set; }
        [BsonRequired]
        [Required]
        public string ApplicationCode { get; set; }

        public string EmailSenderName { get; set; }

        public string EmailSenderAddress { get; set; }

        public string EmailServerAddress { get; set; }

        public int EmailServerPort { get; set; }


    }
}
