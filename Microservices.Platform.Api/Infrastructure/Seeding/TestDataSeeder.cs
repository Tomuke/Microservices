using Microservices.Platform.Api.Application.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Microservices.Platform.Api.Infrastructure.Seeding
{
    public static class TestDataSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IPlatformDatabaseContext>();

                if(!context.Platforms.Any())
                {
                    Console.WriteLine("Seeding database...");

                    context.Platforms.AddRange(
                        new Domain.Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
                        new Domain.Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                        new Domain.Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                    );

                    var s = context.SaveChangesAsync(new System.Threading.CancellationToken()).Result;
                }

                Console.WriteLine("Database successfully seeded.");
            }
        }
    }
}
