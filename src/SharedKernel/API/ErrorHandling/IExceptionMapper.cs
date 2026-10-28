using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.ErrorHandling
{
    public interface IExceptionMapper
    {
        bool CanHandle(Exception exception);
        ProblemDetails MapToProblemDetails(Exception exception, HttpContext context);
    }
}
