using Microservices.Platform.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Microservices.Platform.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<PlatformDatabaseContext>(options => 
                options.UseInMemoryDatabase("InMem")
            );

            return services;
        }
    }
}
