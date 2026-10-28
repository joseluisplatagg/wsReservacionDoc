using Calendar.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Calendar.Application;

namespace Calendar.Presentation
{
    public static class CalendarModuleExtensions
    {
        public static IServiceCollection AddCalendarModule(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registrar Controladores de esta biblioteca de clases
            services.AddControllers()
                    .AddApplicationPart(typeof(CalendarModuleExtensions).Assembly);

            // 2. Registrar los servicios de las capas internas del módulo
           services.AddCalendarInfrastructure(configuration);
           services.AddCalendarApplication(configuration);

            return services;
        }
    }
}
