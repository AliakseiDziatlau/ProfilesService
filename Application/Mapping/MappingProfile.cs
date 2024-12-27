using AutoMapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //DTO to domain
        CreateMap<CreatePatientDto, Patient>();
        CreateMap<CreateDoctorDto, Doctor>();
        CreateMap<CreateReceptionistDto, Receptionist>();

        //domain to DTO
        CreateMap<Patient, PatientResponseDto>();
        CreateMap<Doctor, DoctorResponseDto>();
        CreateMap<Receptionist, ReceptionistResponseDto>();
    }
}