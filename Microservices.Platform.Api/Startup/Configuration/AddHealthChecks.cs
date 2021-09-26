using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Platform.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHealthChecks()
            //    .AddSqlServer(configuration.GetValue<string>("ConnectionString:Value"), name: "CEN_PaymentSchedule database health check");

            return services;
        }
    }
}
