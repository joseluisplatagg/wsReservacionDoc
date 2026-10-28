using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.UseCases.Commands.CrearCita
{
    public class CrearCitaCommandValidator : AbstractValidator<CrearCitaCommand>
    {
        public CrearCitaCommandValidator() 
        {
            RuleFor(x => x.request.Paciente.PacienteNombre)
                .NotEmpty().WithMessage("El nombre del paciente es requerido");

            RuleFor(x => x.request.Paciente.PacienteTelefono)
                .NotEmpty().WithMessage("El telefono del paciente es requerido");

            RuleFor(x => x.request.Paciente.PacienteEdad)
                .NotEmpty().WithMessage("La edad del paciente es requerida");

            RuleFor(x => x.request.DoctorSeleccionado)
                .NotEmpty().WithMessage("El doctor es necesario");

            RuleFor(x => x.request.FechaCita)
                .NotEmpty().WithMessage("La fecha es requerida");

            RuleFor(x => x.request.FechaCita)
                .NotEmpty().WithMessage("La hora es requerida");
        }
    }
}
