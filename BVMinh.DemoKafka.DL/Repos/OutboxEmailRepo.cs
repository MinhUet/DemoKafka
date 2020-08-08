using BVMinh.DemoKafka.DL.Database;
using BVMinh.DemoKafka.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoKafka.DL.Repos
{
    public class OutboxEmailRepo : BaseRepo<OutboxEmail>
    {
        public OutboxEmailRepo(IDbContext dbContext) : base(dbContext)
        {

        }


    }
}
