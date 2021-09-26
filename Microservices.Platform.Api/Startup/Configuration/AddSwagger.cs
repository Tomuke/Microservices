using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Microservices.Platform.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservices.Platform.Api", Version = "v1" });
            });

            return services;
        }
    }
}
