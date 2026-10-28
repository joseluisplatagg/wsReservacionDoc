using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application;
using Reservation.Infrastructure;

namespace Reservation.Presentation
{
    public static class ReservationModuleExtensions
    {
        public static IServiceCollection AddReservationModule(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. Registrar Controladores de esta biblioteca de clases
            services.AddControllers()
                    .AddApplicationPart(typeof(ReservationModuleExtensions).Assembly);

            // 2. Registrar los servicios de las capas internas del módulo
            services.AddResevationInfrastructure(configuration);
            services.AddReservationApplication(configuration);

            return services;
        }
    }
}
