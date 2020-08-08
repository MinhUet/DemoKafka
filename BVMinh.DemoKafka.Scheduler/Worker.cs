using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BVMinh.DemoKafka.Common.Kafka;
using BVMinh.DemoKafka.Common.Utils;
using BVMinh.DemoKafka.DL.Repos;
using BVMinh.DemoKafka.Entity.DTO;
using BVMinh.DemoKafka.Entity.Entities;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BVMinh.DemoKafka.Scheduler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private List<EmailTopic> _topics;
        private readonly EmailTopicRepo _emailTopicRepo;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IRepo<EmailTopic> emailTopicRepo, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _emailTopicRepo = (EmailTopicRepo)emailTopicRepo;
            _topics = new List<EmailTopic>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                List<EmailTopic> topics = _emailTopicRepo.GetAll();
                foreach (var topic in topics)
                {
                    if (!_topics.Exists(et => et.EmailTopicID == topic.EmailTopicID))
                    {
                        Console.WriteLine("Listening to topic:" + topic.EmailTopicName);
                        var t = new Thread(async () =>
                        {
                            var consumerConfig = new ConsumerConfig();
                            _configuration.Bind("Kafka:ConsumerConfig", consumerConfig);
                            consumerConfig.GroupId = topic.EmailTopicName;
                            using (var consumer = new ConsumerWrapper<Null, byte[]>(consumerConfig, topic.EmailTopicName))
                            {
                                while (true)
                                {
                                    try
                                    {
                                        var message = consumer.ReadMessage();
                                        var email = Utility.Deserialize<OutboxEmailDTO>(message);
                                        Console.WriteLine(email.Body);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                            }
                        });
                        t.Start();
                        _topics.Add(topic);
                    }
                }
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
