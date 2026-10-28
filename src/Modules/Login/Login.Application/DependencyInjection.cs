using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Login.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLoginApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Agregamos el uso de AutoMapper, MediatR y FluentValidation
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(DependencyInjection).Assembly));
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            
            return services;
        }
    }
}
