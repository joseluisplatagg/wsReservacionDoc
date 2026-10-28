using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using SharedKernel.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedKernel.Infrastructure
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSharedMiddlewares(this IApplicationBuilder app)
        {
            // 1. MIDDLEWARE DE EXCEPCIONES GLOBAL (Debe ser el primero para atrapar TODO)
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            
            // 2. Configuración de Idiomas en tiempo de ejecución
            var supportedCultures = new[] { "es-MX", "en-US" };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-MX"),
                SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
                SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList()
            });

            // 3. Middlewares nativos estándar y ordenados de ASP.NET Core
            app.UseRouting();

            // Aplicamos la política CORS que registramos en el paso anterior
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();
            
            return app;
        }
    }
}
