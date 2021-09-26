using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Microservices.Platform.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
        {
            services
                .AddMvc(options => options.EnableEndpointRouting = false)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            return services;
        }
    }
}
