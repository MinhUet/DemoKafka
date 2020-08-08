using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Entity.Entities
{
    [Serializable]
    public class BaseEntity
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }

    }
}
