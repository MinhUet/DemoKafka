using BVMinh.DemoKafka.Common.Kafka;
using BVMinh.DemoKafka.Common.Utils;
using BVMinh.DemoKafka.DL.Repos;
using BVMinh.DemoKafka.Entity.DTO;
using BVMinh.DemoKafka.Entity.Entities;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVMinh.DemoKafka.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private ApplicationRepo _repo;
        private readonly ProducerConfig _producerConfig;

        public EmailController(IRepo<Application> repo, ProducerConfig producerConfig)
        {
            _repo = (ApplicationRepo)repo;
            _producerConfig = producerConfig;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OutboxEmailDTO email)
        {
            email.EmailID = ObjectId.GenerateNewId().ToString();
            using (var producer = new ProducerWrapper<Null, byte[]>(_producerConfig, email.ApplicationCode))
            {
                await producer.SendMessage(Utility.SerializeToByteArray(email));
            }
            return Ok(email.EmailID);
        }
    }
}
