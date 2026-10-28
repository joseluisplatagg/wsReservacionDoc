using AutoMapper;
using Calendar.Application.DTOs.Responses;
using Calendar.Domain.AggregateRoots;
using Calendar.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calendar.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            EnumMappingProfile();

            CommandToDomainMappingProfile();

            DomainToViewModelMappingProfile();
        }

        private void EnumMappingProfile()
        {
            // Mapeo de enumeraciones a DTOs
            // CreateMap<Status, StatusDto>().ReverseMap();        
        }

        private void CommandToDomainMappingProfile()
        {
            // Mapeo de comandos a entidades del dominio
            CreateMap<CitaAggregateRoot, CitaResponseDTO>();

            CreateMap<Paciente, PacienteResponseDTO>();
            CreateMap<CitaAggregateRoot, CitaResponseDTO>()
            .ForMember(
                dest => dest.DoctorAsignado,
                opt => opt.MapFrom(src => src.DoctorSeleccionadoCita))
            .ForMember(
                dest => dest.Paciente,
                opt => opt.MapFrom(src => src.Paciente))
            .ForMember(
                dest => dest.DiaCita,
                opt => opt.MapFrom(src => src.DiaCita))
            .ForMember(
                dest => dest.HoraCita,
                opt => opt.MapFrom(src => src.HoraCita));

        }

        private void DomainToViewModelMappingProfile()
        {
            // Mapeo de entidades del dominio a ViewModels
            // CreateMap<DomainEntity, DomainViewModel>();
        }
    }
}
