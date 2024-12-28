using AutoMapper;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.Application.Handlers.PatientHandlers;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //commands to models
        CreateMap<CreatePatientCommand, Patient>();
        CreateMap<UpdatePatientCommand, Patient>();

        CreateMap<CreateDoctorCommand, Doctor>();
        CreateMap<UpdateDoctorCommand, Doctor>();

        CreateMap<CreateReceptionistCommand, Receptionist>();
        CreateMap<UpdateReceptionistCommand, Receptionist>();

        //models to DTOs for answers
        CreateMap<Patient, PatientResponseDto>();
        CreateMap<Doctor, DoctorResponseDto>();
        CreateMap<Receptionist, ReceptionistResponseDto>();
    }
}