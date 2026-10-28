using Calendar.Application.DTOs.Requests;
using Calendar.Application.DTOs.Responses;
using MediatR;
using SharedKernel.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.UseCases.Commands.CrearCita
{
    public record CrearCitaCommand(CrearCitaRequestDTO request) : IRequest<OperationResult<CrearCitaResponseDTO>>;
}
