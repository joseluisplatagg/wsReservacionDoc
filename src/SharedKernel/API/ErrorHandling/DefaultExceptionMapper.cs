using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.API.Localization;
using SharedKernel.Application.Exceptions;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.ErrorHandling
{
    public class DefaultExceptionMapper(ILocalizer localizer) : IExceptionMapper
    {
        public bool CanHandle(Exception exception) => true;

        public ProblemDetails MapToProblemDetails(Exception exception, HttpContext context)
        {
            var message = localizer.GetMessage(exception);

            return exception switch
            {
                ValidationException ve => ProblemDetailsFactory.Validation(ve, context, localizer),
                DomainException de => ProblemDetailsFactory.Domain(de, context, message),
                UseCaseException uce => ProblemDetailsFactory.UseCase(uce, context, message),
                NotFoundException nfe => ProblemDetailsFactory.NotFound(nfe, context),
                ForbiddenException fe => ProblemDetailsFactory.Forbidden(fe, context),
                UnauthorizedAccessException ua => ProblemDetailsFactory.Unauthorized(ua, context),
                _ => ProblemDetailsFactory.Unexpected(exception, context)
            };
        }
    }
}
