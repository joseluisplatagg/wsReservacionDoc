using AutoMapper;
using Calendar.Application.Contracts.Data;
using Calendar.Application.DTOs.Responses;
using Calendar.Application.UseCases.Queries.ListarCitas;
using Calendar.Domain.AggregateRoots;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.UseCases.Queries.ObtenerCitaId
{
    public class ObtenerCitaIdQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ObtenerCitaIdQueryHandler> logger
        ) : IRequestHandler<ObtenerCitaIdQuery, OperationResult<ObtenerCitaResponseDTO>>
    {
        public async Task<OperationResult<ObtenerCitaResponseDTO>> Handle(ObtenerCitaIdQuery request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<CitaAggregateRoot>();
            var cita = await repository.GetByIdAsync(request.CitaId);

            return OperationResult.With(mapper.Map<ObtenerCitaResponseDTO>(cita));
        }
    }
}
