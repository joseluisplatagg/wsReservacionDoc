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

namespace Calendar.Application.UseCases.Commands.CrearCita;

public class CrearCitaCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ILogger<CrearCitaCommandHandler> logger
    ) : IRequestHandler<CrearCitaCommand, OperationResult<CrearCitaResponseDTO>>
{
    public async Task<OperationResult<CrearCitaResponseDTO>> Handle(CrearCitaCommand request, CancellationToken cancellationToken)
    {
        var cita = new CitaAggregateRoot()
        {
            Id = Guid.NewGuid(),
            Paciente = new Domain.ValueObjects.Paciente(
                request.request.Paciente.PacienteNombre,
                request.request.Paciente.PacienteTelefono,
                request.request.Paciente.PacienteEdad),
            DoctorSeleccionadoCita = request.request.DoctorSeleccionado,
            MotivoCita = request.request.MotivoCita,
            DiaCita = request.request.FechaCita,
            HoraCita = request.request.HoraCita
        };

        await unitOfWork.GetRepository<CitaAggregateRoot>().AddAsync(cita);
        await unitOfWork.CompleteAsync();
        return OperationResult.With(new CrearCitaResponseDTO { Success = true });
    }
}

