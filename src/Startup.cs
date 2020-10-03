using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Demo.Aws.Entities;
using Demo.Aws.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Demo.Aws.Services.Interfaces;
using Demo.Aws.Services;
using Microsoft.Extensions.Configuration;
using Amazon.SQS;
using Amazon;

namespace Demo.Aws
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddControllers();
            services                
                .AddScoped<ITransactionService, TransactionService>()              
                .AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>))
                .AddSingleton<IAmazonSQS,AmazonSQSClient>();
            services.AddDbContext<TransactionContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("DemoDb")),
                ServiceLifetime.Scoped);
            //services.Configure<AppSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TransactionContext transactionContext)
        {
            transactionContext.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            //Pick from config :)
            AWSConfigs.AWSRegion = "us-east-1";

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                 endpoints.MapControllers();
            });
           
        }
    }
}
