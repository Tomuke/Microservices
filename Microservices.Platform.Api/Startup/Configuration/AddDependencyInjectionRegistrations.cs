using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Platform.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjectionRegistrations(this IServiceCollection services)
        {
            //services.Scan(scan => scan
            //    .FromAssemblyOf<Startup>()
            //    .AddClasses(classes => classes.NotInNamespaces(typeof(IExceptionFilter).Namespace))
            //    .AsImplementedInterfaces()
            //    .WithTransientLifetime());

            return services;
        }
    }
}
