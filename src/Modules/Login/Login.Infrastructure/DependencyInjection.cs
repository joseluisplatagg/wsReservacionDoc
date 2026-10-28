using Login.Application.Contracts.Data;
using Login.Infrastructure.Data;
using Login.Infrastructure.Data.Repositories;
using Login.Infrastructure.Services.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLoginInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ContextDb")!;

            // Configuración normal de tu DbContext...
            services.AddDbContext<LoginContextDb>(options =>
                 options.UseNpgsql(connectionString!,
                     x => x.MigrationsHistoryTable("__login_ef_migrations_history", "infra")
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
