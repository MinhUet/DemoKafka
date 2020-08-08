using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVMinh.DemoKafka.Common.ConfigObjects;
using BVMinh.DemoKafka.DL.Database;
using BVMinh.DemoKafka.DL.Repos;
using BVMinh.DemoKafka.Entity.Entities;
using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BVMinh.DemoKafka.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<EmailDatabaseSettings>(
        Configuration.GetSection(nameof(EmailDatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<EmailDatabaseSettings>>().Value);
            services.AddSingleton<IDbContext, MongoDbContext>();
            services.AddScoped<IRepo<Application>, ApplicationRepo>();
            var producerConfig = new ProducerConfig();
            Configuration.Bind("Kafka:ProducerConfig", producerConfig);
            services.AddSingleton(producerConfig);
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
