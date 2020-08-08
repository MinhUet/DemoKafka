using BVMinh.DemoKafka.Common.ConfigObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.DL.Database
{
    public class MongoDbContext : IDbContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _mongoDatabase;

        public IMongoDatabase MongoDatabase { get => _mongoDatabase; }
        public MongoDbContext(IDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _mongoDatabase = _client.GetDatabase(settings.DatabaseName);
        }
    }
}
