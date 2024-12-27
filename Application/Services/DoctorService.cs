using ProfilesService.Application.Interfaces;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;

    public DoctorService(IDoctorRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<DoctorResponseDto> GetDoctorByIdAsync(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");

        return new DoctorResponseDto
        {
            Id = doctor.Id,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            MiddleName = doctor.MiddleName,
            DateOfBirth = doctor.DateOfBirth,
            AccountId = doctor.AccountId,
            SpecializationId = doctor.SpecializationId,
            OfficeId = doctor.OfficeId,
            CareerStartYear = doctor.CareerStartYear,
            Status = doctor.Status
        };
    }

    public async Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync()
    {
        var doctors = await _repository.GetAllAsync();
        return doctors.Select(d => new DoctorResponseDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            MiddleName = d.MiddleName,
            DateOfBirth = d.DateOfBirth,
            AccountId = d.AccountId,
            SpecializationId = d.SpecializationId,
            OfficeId = d.OfficeId,
            CareerStartYear = d.CareerStartYear,
            Status = d.Status
        });
    }

    public async Task CreateDoctorAsync(CreateDoctorDto dto)
    {
        var doctor = new Doctor
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            DateOfBirth = dto.DateOfBirth,
            AccountId = dto.AccountId,
            SpecializationId = dto.SpecializationId,
            OfficeId = dto.OfficeId,
            CareerStartYear = dto.CareerStartYear,
            Status = dto.Status
        };

        await _repository.CreateAsync(doctor);
    }


    public async Task UpdateDoctorAsync(int id, CreateDoctorDto dto)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");

        doctor.FirstName = dto.FirstName;
        doctor.LastName = dto.LastName;
        doctor.MiddleName = dto.MiddleName;
        doctor.DateOfBirth = dto.DateOfBirth;
        doctor.AccountId = dto.AccountId;
        doctor.SpecializationId = dto.SpecializationId;
        doctor.OfficeId = dto.OfficeId;
        doctor.CareerStartYear = dto.CareerStartYear;
        doctor.Status = dto.Status;

        await _repository.UpdateAsync(doctor);
    }

    public async Task DeleteDoctorAsync(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");

        await _repository.DeleteAsync(id);
    }
}