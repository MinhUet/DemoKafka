using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVMinh.DemoKafka.Common.ConfigObjects;
using BVMinh.DemoKafka.DL.Database;
using BVMinh.DemoKafka.DL.Repos;
using BVMinh.DemoKafka.Entity.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BVMinh.DemoKafka.Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    services.Configure<EmailDatabaseSettings>(
        configuration.GetSection(nameof(EmailDatabaseSettings)));

                    services.AddSingleton<IDatabaseSettings>(sp =>
                        sp.GetRequiredService<IOptions<EmailDatabaseSettings>>().Value);

                    services.AddSingleton<IDbContext, MongoDbContext>();
                    services.AddSingleton<IRepo<EmailTopic>, EmailTopicRepo>();
                    services.AddHostedService<Worker>();
                });
    }
}
