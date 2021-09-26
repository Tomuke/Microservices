using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Platform.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<MonthlyInstalmentSettings>(configuration.GetSection(MonthlyInstalmentSettings.SECTION_NAME));

            //services.Configure<ExistingMonthlyInstalmentSettings>(configuration.GetSection(ExistingMonthlyInstalmentSettings.SECTION_NAME));

            return services;
        }
    }
}
