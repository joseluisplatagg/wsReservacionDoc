using Calendar.Application.DTOs.Responses;
using MediatR;
using SharedKernel.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.UseCases.Queries.ListarCitas
{
    public record ListarCitasQuery() : IRequest<OperationResult<ListarCitasResponseDTO>>;
}
