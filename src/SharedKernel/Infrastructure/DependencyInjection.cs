using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedKernel.API.Configurations;
using SharedKernel.API.ErrorHandling;
using SharedKernel.API.Localization;
using SharedKernel.API.Middlewares;
using System.Globalization;

namespace SharedKernel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {

            #region Common Setup API  
            // Configuración de la internacionalización para los mensajes.
            services.AddLocalization();

            var supportedCultures = new[]
            {
            new CultureInfo("es-MX"),
            new CultureInfo("en-US")
        };
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("es-MX");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddSingleton(typeof(ILocalizer), typeof(Localizer));
            // Configura los controladores personalizados para la aplicación
            services.AddCustomControllers();
            // Configura la lectura de tokens JWT para la autenticación y autorización en la aplicación
            services.AddJwtReader();
            // Habilita y configura el versionado de la API
            services.AddCustomApiVersioning();
            
            // Configura las políticas de CORS personalizadas para controlar 
            // el acceso desde orígenes externos.
            services.AddCustomCors(configuration);
            // Agrega un servicio para acceder al contexto HTTP actual en cualquier parte de la aplicación
            services.AddHttpContextAccessor();
            // Registra el middleware global para manejar excepciones no controladas en la aplicación
            services.AddTransient<IExceptionMapper, DefaultExceptionMapper>();
            // Resgistra el servicio para obtener información sobre el usuario autenticado en la aplicación
            services.AddScoped<ICurrentUserProvider, HttpCurrentUserProvider>();
            // 4. MediatR Global (Si tus módulos comparten un Bus de comandos en memoria)
            // Escanea los manejadores de eventos o commands transversales si existieran
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            #endregion

            return services;
        }
    }
}
