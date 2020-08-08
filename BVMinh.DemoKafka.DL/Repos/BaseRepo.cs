using BVMinh.DemoKafka.Common.Utils;
using BVMinh.DemoKafka.DL.Database;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.DL.Repos
{
    public class BaseRepo<T> : IRepo<T>
    {
        protected string _collectionName { get; set; }
        protected IMongoCollection<T> _collection { get; set; }
        private readonly MongoDbContext _mongoDbContext;
        public BaseRepo(IDbContext dbContext)
        {
            _collectionName = Utility.GetTypeName<T>();
            _mongoDbContext = (MongoDbContext)dbContext;
            _collection = _mongoDbContext.MongoDatabase.GetCollection<T>(_collectionName);
        }

    }
}
