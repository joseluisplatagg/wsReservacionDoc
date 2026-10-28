using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Application;
using Users.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Presentation
{
    public static class UsersModuleExtensions
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registrar Controladores de esta biblioteca de clases
            services.AddControllers()
                    .AddApplicationPart(typeof(UsersModuleExtensions).Assembly);

            // 2. Registrar los servicios de las capas internas del módulo
            services.AddUsersInfrastructure(configuration);
            services.AddUsersApplication(configuration);

            return services;
        }
    }
}
