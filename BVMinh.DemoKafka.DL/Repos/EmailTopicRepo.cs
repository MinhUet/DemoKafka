using BVMinh.DemoKafka.DL.Database;
using BVMinh.DemoKafka.Entity.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.DL.Repos
{
    public class EmailTopicRepo : BaseRepo<EmailTopic>
    {
        public EmailTopicRepo(IDbContext dbContext) : base(dbContext)
        {

        }

        public List<EmailTopic> GetAll()
        {
            return _collection.AsQueryable().ToList();
        }
    }
}
