using Calendar.Application.DTOs.Requests;
using Calendar.Application.DTOs.Responses;
using Calendar.Application.UseCases.Commands.CrearCita;
using Calendar.Application.UseCases.Queries.ListarCitas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.API;
using SharedKernel.API.DTO;
using SharedKernel.API.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Presentation.Controllers
{
    public class CalendarController(IMediator mediator, ILocalizer localizer) : RootController(mediator, localizer)
    {
        /// <summary>
        /// Crear cita
        /// </summary>
        /// <param name="request">Contenido de cita</param>
        /// <param name="cancellationToken">A token to monitor for request cancellation.</param>
        /// <returns>The requested file details if found.</returns>
        /// <response code="200">Cita creada.</response>
        /// <response code="400">Invalid input data provided.</response>
        /// <response code="401">User is not authenticated.</response>
        /// <response code="403">User does not have permission to access this file.</response>
        /// <response code="404">The requested file was not found.</response>
        /// <response code="422">Business rule violation occurred during the request.</response>
        /// <response code="500">An internal server error occurred while processing the request.</response>
        [HttpPost("crear-cita")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CrearCitaResponseDTO>> CrearCitaAsync(
            [FromBody] CrearCitaRequestDTO request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CrearCitaCommand(request), cancellationToken);
            return Ok(true);
        }

        /// <summary>
        /// Obtener todas las citas
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
        [HttpGet("obtener-citas")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListarCitasResponseDTO>> ObtenerCitasAsync(
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new ListarCitasQuery(),cancellationToken);
            return Ok(response);
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
        [HttpPost("block-timeslot")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> BlockTimeslotAsync(
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
        [HttpPost("Book-slot-internal")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> BookSlotInternalAsync(
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
        [HttpPost("create-calendar")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CreateCalendarAsync(
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
        [HttpPost("setup-working-hours")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> SetupWorkingHOursAsync(
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
        [HttpPost("update-business-rules")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateBusinessRulesAsync(
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
        [HttpGet("free-slots")]
        [ProducesResponseType(typeof(APIResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> FreeSlotsAsync(
            CancellationToken cancellationToken)
        {

            return Ok(true);
        }
    }
    
}
