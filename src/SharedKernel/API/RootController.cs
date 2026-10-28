using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.API.Localization;

namespace SharedKernel.API
{
    [ApiController]
    //[Authorize]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public abstract class RootController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly ILocalizer _localizer;

        protected RootController(IMediator mediator, ILocalizer localizer)
        {
            _mediator = mediator;
            _localizer = localizer;
        }
    }
}