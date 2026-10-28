using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Contracts.Data;
using Reservation.Infrastructure.Data;
using Reservation.Infrastructure.Data.Repositories;
using Reservation.Infrastructure.Services.Permission;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddResevationInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ContextDb")!;

            // Configuración normal de tu DbContext...
            services.AddDbContext<ReservationContextDb>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("ContextDb")!,
                     x => x.MigrationsHistoryTable("__ecm_ef_migrations_history", "infra")
                 )
                     //.UseSnakeCaseNamingConvention() // Convierte nombres de tablas y columnas a snake_case
                     .EnableSensitiveDataLogging() // Para ver los valores de las consultas en la consola
             );

            // Repositorios, UnitOfWork y QueryStores
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Registramos tu servicio de Laserfiche vinculándolo a la interfaz con su etiqueta
            services.AddTransient<AuthorizationHeaderHandler>();
            services.Configure<SecurityProviderOptions>(configuration.GetSection(SecurityProviderOptions.SectionName));


            return services;
        }
    }
}
