using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.Entity.Entities
{
    [Serializable]
    public class Recipient
    {
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        [BsonDictionaryOptions]
        public Dictionary<String, object> MergeData { get; set; }
        [BsonDictionaryOptions]
        public Dictionary<String, object> CustomArgs { get; set; }

    }
}
