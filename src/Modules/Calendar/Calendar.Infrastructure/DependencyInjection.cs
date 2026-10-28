using Calendar.Application.Contracts.Data;
using Calendar.Infrastructure.Data;
using Calendar.Infrastructure.Data.Repositories;
using Calendar.Infrastructure.Services.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Calendar.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCalendarInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            // Configuración normal de tu DbContext...
            services.AddDbContext<CalendarContextDb>(options =>
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
