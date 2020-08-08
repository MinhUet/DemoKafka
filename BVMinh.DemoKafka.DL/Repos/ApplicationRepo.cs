using BVMinh.DemoKafka.DL.Database;
using BVMinh.DemoKafka.Entity.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BVMinh.DemoKafka.DL.Repos
{
    public class ApplicationRepo : BaseRepo<Application>
    {
        public ApplicationRepo(IDbContext dbContext) : base(dbContext)
        {
        }

        public void InsertOne(Application application)
        {
            _collection.InsertOne(application);
        }

        public IQueryable<Application> Get()
        {
            return _collection.AsQueryable();
        }
    }
}
