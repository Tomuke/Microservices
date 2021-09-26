using MediatR;
using Microservices.Platform.Api.Application.Abstractions;
using Microservices.Platform.Api.Domain;
using Microservices.Platform.Api.Infrastructure;
using Microservices.Platform.Api.Infrastructure.Repositories;
using Microservices.Platform.Api.Infrastructure.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Microservices.Platform.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwagger();

            services.AddDatabaseContext();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IPlatformDatabaseContext, PlatformDatabaseContext>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();

            services.AddMediatR(typeof(Startup));

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine("Configuring application pipeline...");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservices.Platform.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();

            TestDataSeeder.Seed(app);

            Console.WriteLine("Application pipeline configuration completed.");
        }

        /*
         *  docker build -t tommarshall39/platform-service .
         *  docker build -f Microservices.Platform.Api/Dockerfile -t tommarshall39/platform-service .
         *  docker push tommarshall39/platform-service
         *  docker run  -p 8080:80 -d -t tommarshall39/platform-service
         *  
         *  kubectl get deployments
         *  kubectl get pods
         *  kubectl get services
         *  kubectl apply -f platforms-deployment.yaml
         *  kubectl apply -f platforms-node-port-service.yaml
         */
    }
}
