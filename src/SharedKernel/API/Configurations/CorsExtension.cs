using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.API.Configurations
{
    public static class CorsExtension
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            var frontendUrl = configuration["CorsSettings:FrontendUrl"] ?? "http://localhost:5173";
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(frontendUrl)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                );
            });

            return services;
        }
    }
}
