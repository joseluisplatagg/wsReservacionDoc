using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Application;
using Services.Infrastructure;

namespace Services.Presentation
{
    public static class ServicesModuleExtensions
    {
        public static IServiceCollection AddServicesModule(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registrar Controladores de esta biblioteca de clases
            services.AddControllers()
                    .AddApplicationPart(typeof(ServicesModuleExtensions).Assembly);

            // 2. Registrar los servicios de las capas internas del módulo
            services.AddServicesInfrastructure(configuration);
            services.AddServicesApplication(configuration);

            return services;
        }
    }
}
