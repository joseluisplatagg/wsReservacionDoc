using AutoMapper;
using Calendar.Application.Contracts.Data;
using Calendar.Application.DTOs.Responses;
using Calendar.Domain.AggregateRoots;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.API.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.UseCases.Queries.ListarCitas
{
    public class ListarCitasQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<ListarCitasQueryHandler> logger
        ) : IRequestHandler<ListarCitasQuery, OperationResult<ListarCitasResponseDTO>>
    {
        public async Task<OperationResult<ListarCitasResponseDTO>> Handle(ListarCitasQuery request, CancellationToken cancellationToken)
        {
            var citas = await unitOfWork.GetRepository<CitaAggregateRoot>()
                .GetAllAsync();

            var citasDtoList = mapper.Map<List<CitaResponseDTO>>(citas);

            Dictionary<DateOnly, TimeOnly[]> reservaciones = citas.GroupBy(c => c.DiaCita).ToDictionary(
                                                                            grupo => grupo.Key,
                                                                            grupo => grupo.Select(c => new TimeOnly(c.HoraCita.Hour, c.HoraCita.Minute)).ToArray());

            return OperationResult.With(
                new ListarCitasResponseDTO
                {
                    Citas = citasDtoList,
                    Reservaciones = reservaciones
                });
        }
    }
}
