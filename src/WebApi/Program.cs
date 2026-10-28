using Calendar.Presentation;
using Prometheus;
using Serilog;
using SharedKernel.API.Configurations;
using SharedKernel.Infrastructure;
using WebApi.Configuration;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Inicialización y configuración de Serilog
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
    Log.Information("Iniciando el Monolito Modular...");   

    // Indicarle a ASP.NET Core que use Serilog como su motor de logs
    builder.Host.UseSerilog();
    builder.Services.AddSharedInfrastructure(builder.Configuration,builder.Environment);  

    // Add services to the container.    
    builder.Services.AddHealthChecks();

    // Link to Modules
    builder.Services.AddCalendarModule(builder.Configuration);

    // Registra la documentación OpenAPI con Scalar (solo en no-producción)
    if (!builder.Environment.IsProduction())
    {
        builder.Services.AddCustomOpenApi();
    }

    var app = builder.Build();
    
    app.UseHttpMetrics();
    app.MapMetrics();
    // Custom Middlewares
    app.UseSharedMiddlewares();
    app.UseSerilogRequestLogging();
    if (!app.Environment.IsProduction()) app.UseCustomOpenApi();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "El host terminó inesperadamente");
}
finally
{
    Log.CloseAndFlush(); // Asegura que se escriban todos los logs pendientes antes de cerrar
}
