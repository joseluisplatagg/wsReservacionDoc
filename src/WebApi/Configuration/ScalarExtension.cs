using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text.Json.Nodes;

namespace WebApi.Configuration
{
    public static class ScalarExtension
    {
        public static IServiceCollection AddCustomOpenApi(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider()
                .GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                services.AddOpenApi(description.GroupName, options =>
                {
                    options.AddDocumentTransformer((document, context, ct) =>
                    {
                        document.Info = new OpenApiInfo
                        {
                            Title = "Example - Developed by JLPG Services®️",
                            Version = description.ApiVersion.ToString(),
                            Description = description.IsDeprecated
                                ? "This API version has been deprecated. Please use one of the new APIs available from the explorer."
                                : null
                        };
                        return Task.CompletedTask;
                    });

                    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
                    options.AddOperationTransformer<AcceptLanguageHeaderTransformer>();
                });
            }

            return services;
        }

        public static IApplicationBuilder UseCustomOpenApi(this WebApplication app)
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                app.MapOpenApi($"/openapi/{description.GroupName}.json")
                   .WithGroupName(description.GroupName);
            }

            app.MapScalarApiReference("/docs", options =>
            {
                options.Title = "Example API";
                options.Theme = ScalarTheme.Default;
                options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);

                options.OpenApiRoutePattern = "/openapi/{documentName}.json";
            });

            return app;
        }
    }

    internal sealed class BearerSecuritySchemeTransformer : IOpenApiDocumentTransformer
    {
        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
            CancellationToken cancellationToken)
        {
            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();

            document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Ingrese el token JWT para autenticarse."
            };

            var operations = document.Paths.Values.SelectMany(p => p?.Operations?.Values ?? Enumerable.Empty<OpenApiOperation>());

            foreach (var operation in operations)
            {
                operation.Security ??= [];
                operation.Security.Add(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecuritySchemeReference("Bearer", document),
                    new List<string>()
                }
            });
            }

            return Task.CompletedTask;
        }
    }

    internal sealed class AcceptLanguageHeaderTransformer : IOpenApiOperationTransformer
    {
        public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context,
            CancellationToken cancellationToken)
        {
            var hasAnonymous = context.Description.ActionDescriptor.EndpointMetadata
                .OfType<AllowAnonymousAttribute>().Any();

            if (hasAnonymous)
            {
                operation.Security?.Clear();
            }

            operation.Parameters ??= [];
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Language preference (optional), default is 'es-MX'.",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = JsonSchemaType.String,
                    Enum =
                    [
                        JsonValue.Create("es-MX")!,
                    JsonValue.Create("en-US")!,
                    JsonValue.Create("")!
                    ]
                }
            });

            return Task.CompletedTask;
        }
    }
}
