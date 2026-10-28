using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.API;
using SharedKernel.API.DTO;
using SharedKernel.API.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Presentation.Controllers
{
    public class ServicesController(IMediator mediator, ILocalizer localizer) : RootController(mediator, localizer)
    {
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
        [HttpPost("assing-provider-to-service")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> AssignProviderToServiceAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpPost("service-availabality")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ConfigureServiceAvailabalityAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpPost("create")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CreateServiceAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpPut("desactivate")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DesactivateServiceAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpPatch("update")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateServiceAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpPost("elegible-service")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> GetElegibleServiceForProviderAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpGet("service-pricing-matrix")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> GetServicePricingMatrixAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
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
        [HttpGet("service-catalog")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> SearchServiceCatalogAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
        }
       
    }
}
