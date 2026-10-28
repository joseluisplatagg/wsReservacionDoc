using Login.Application.UseCases.Commands.CreateIdentityUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.API;
using SharedKernel.API.DTO;
using SharedKernel.API.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Presentation.Controllers
{
    public class LoginController(IMediator _mediator, ILocalizer _localizer) : RootController(_mediator, _localizer)
    {
        /// <summary>
        /// Registre User.
        /// </summary>
        /// <param name="request">Content file and person id</param>
        /// <param name="cancellationToken">A token to monitor for request cancellation.</param>
        /// <returns>The requested file details if found.</returns>
        /// <response code="200">The file was successfully uploaded.</response>
        /// <response code="400">Invalid input data provided.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission to access this file.</response>
        /// <response code="404">The requested file was not found.</response>
        /// <response code="422">Business rule violation occurred during the request.</response>
        /// <response code="500">An internal server error occurred while processing the request.</response>
        [HttpPost("register")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> RegisterAsync(
            [FromBody] CreateIdentityUserCommand command,
            CancellationToken cancellationToken)
        {
            Guid userId = await _mediator.Send(command);
            return Ok(userId);
        }
        /// <summary>
        /// Login User.
        /// </summary>
        /// <param name="request">Content file and person id</param>
        /// <param name="cancellationToken">A token to monitor for request cancellation.</param>
        /// <returns>The requested file details if found.</returns>
        /// <response code="200">The file was successfully uploaded.</response>
        /// <response code="400">Invalid input data provided.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission to access this file.</response>
        /// <response code="404">The requested file was not found.</response>
        /// <response code="422">Business rule violation occurred during the request.</response>
        /// <response code="500">An internal server error occurred while processing the request.</response>
        [HttpPost("authenticate-user")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> LoginAsync(
            CancellationToken cancellationToken)
        {            

            return Ok(true);
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="request">Content file and person id</param>
        /// <param name="cancellationToken">A token to monitor for request cancellation.</param>
        /// <returns>The requested file details if found.</returns>
        /// <response code="200">The file was successfully uploaded.</response>
        /// <response code="400">Invalid input data provided.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission to access this file.</response>
        /// <response code="404">The requested file was not found.</response>
        /// <response code="422">Business rule violation occurred during the request.</response>
        /// <response code="500">An internal server error occurred while processing the request.</response>
        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ResetPasswodAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="request">Content file and person id</param>
        /// <param name="cancellationToken">A token to monitor for request cancellation.</param>
        /// <returns>The requested file details if found.</returns>
        /// <response code="200">The file was successfully uploaded.</response>
        /// <response code="400">Invalid input data provided.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission to access this file.</response>
        /// <response code="404">The requested file was not found.</response>
        /// <response code="422">Business rule violation occurred during the request.</response>
        /// <response code="500">An internal server error occurred while processing the request.</response>
        [HttpGet("user-state")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> GetUserStateAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
        }
    }
}
