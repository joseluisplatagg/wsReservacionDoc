using Microsoft.AspNetCore.Http;
using SharedKernel.API.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware(RequestDelegate next, IEnumerable<IExceptionMapper> mappers)
    {
        private readonly RequestDelegate _next = next;
        private readonly IEnumerable<IExceptionMapper> _mappers = mappers;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var mapper = _mappers.First(m => m.CanHandle(ex));
                var problem = mapper.MapToProblemDetails(ex, context);

                context.Response.StatusCode = problem.Status!.Value;
                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}
