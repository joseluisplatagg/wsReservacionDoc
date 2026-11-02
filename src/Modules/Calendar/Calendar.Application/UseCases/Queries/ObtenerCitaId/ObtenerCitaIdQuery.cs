using Calendar.Application.DTOs.Responses;
using MediatR;
using SharedKernel.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.UseCases.Queries.ObtenerCitaId
{
    public record ObtenerCitaIdQuery(Guid CitaId) : IRequest<OperationResult<ObtenerCitaResponseDTO>>;
}
