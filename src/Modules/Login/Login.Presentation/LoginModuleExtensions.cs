using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Login.Application;
using Login.Infrastructure;
namespace Login.Presentation
{
    public static class LoginModuleExtensions
    {
        public static IServiceCollection AddLoginModule(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registrar Controladores de esta biblioteca de clases
            services.AddControllers()
                    .AddApplicationPart(typeof(LoginModuleExtensions).Assembly);

            // 2. Registrar los servicios de las capas internas del módulo
            services.AddLoginInfrastructure(configuration);
            services.AddLoginApplication(configuration);

            return services;
        }
    }
}
