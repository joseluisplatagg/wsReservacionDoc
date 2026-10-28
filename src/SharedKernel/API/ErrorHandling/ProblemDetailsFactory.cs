using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.API.Localization;
using SharedKernel.Application.Exceptions;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SharedKernel.API.ErrorHandling
{
    public static class ProblemDetailsFactory
    {
        public static ProblemDetails Validation(ValidationException ex, HttpContext context, ILocalizer localizer)
        {
            var problem = new ProblemDetails
            {
                Title = "Validation Failed",
                Status = StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Detail = localizer.GetMessage("DetailMessage"),
                Instance = context.Request.Path
            };

            problem.Extensions["errors"] = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => localizer.GetMessage(e.ErrorMessage)).ToArray()
                );
            return problem;
        }

        public static ProblemDetails Domain(DomainException ex, HttpContext context, string message)
        {
            var problem = new ProblemDetails
            {
                Title = "Business Rule Violation",
                Status = StatusCodes.Status422UnprocessableEntity,
                Type = "https://tools.ietf.org/html/rfc4918#section-11.2",
                Detail = message,
                Instance = context.Request.Path
            };

            problem.Extensions["errorCode"] = ex.ErrorCode;
            return problem;
        }

        public static ProblemDetails UseCase(UseCaseException ex, HttpContext context, string message)
        {
            var problem = new ProblemDetails
            {
                Title = "Use Case Error",
                Status = StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Detail = message,
                Instance = context.Request.Path
            };

            problem.Extensions["errorCode"] = ex.ErrorCode;
            return problem;
        }

        public static ProblemDetails NotFound(NotFoundException ex, HttpContext context)
        {
            var problem = new ProblemDetails
            {
                Title = "Resource Not Found",
                Status = StatusCodes.Status404NotFound,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            return problem;
        }

        public static ProblemDetails Forbidden(ForbiddenException ex, HttpContext context)
        {
            var problem = new ProblemDetails
            {
                Title = "Access Denied",
                Status = StatusCodes.Status403Forbidden,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            problem.Extensions["permission"] = ex.Permission;

            return problem;
        }

        public static ProblemDetails Unauthorized(UnauthorizedAccessException ex, HttpContext context)
        {
            var problem = new ProblemDetails
            {
                Title = "Unauthorized",
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            return problem;
        }

        public static ProblemDetails Unexpected(Exception ex, HttpContext context)
        {
            return new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Detail = "An unexpected error occurred. Please try again later.",
                Instance = context.Request.Path
            };
        }
    }
}
