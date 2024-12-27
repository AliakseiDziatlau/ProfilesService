using ProfilesService.Application.Interfaces;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<PatientResponseDto> GetPatientByIdAsync(int id)
    {
        var patient = await _repository.GetByIdAsync(id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {id} not found.");

        return new PatientResponseDto
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            MiddleName = patient.MiddleName,
            DateOfBirth = patient.DateOfBirth,
            IsLinkedToAccount = patient.IsLinkedToAccount,
            AccountId = patient.AccountId
        };
    }

    public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
    {
        var patients = await _repository.GetAllAsync();
        return patients.Select(p => new PatientResponseDto
        {
            Id = p.Id,
            FirstName = p.FirstName,
            LastName = p.LastName,
            MiddleName = p.MiddleName,
            DateOfBirth = p.DateOfBirth,
            IsLinkedToAccount = p.IsLinkedToAccount,
            AccountId = p.AccountId
        });
    }

    public async Task CreatePatientAsync(CreatePatientDto dto)
    {
        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            DateOfBirth = dto.DateOfBirth,
            IsLinkedToAccount = dto.IsLinkedToAccount,
            AccountId = dto.AccountId
        };

        await _repository.CreateAsync(patient);
    }

    public async Task UpdatePatientAsync(int id, CreatePatientDto dto)
    {
        var patient = await _repository.GetByIdAsync(id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {id} not found.");

        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.MiddleName = dto.MiddleName;
        patient.DateOfBirth = dto.DateOfBirth;
        patient.IsLinkedToAccount = dto.IsLinkedToAccount;
        patient.AccountId = dto.AccountId;

        await _repository.UpdateAsync(patient);
    }

    public async Task DeletePatientAsync(int id)
    {
        var patient = await _repository.GetByIdAsync(id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {id} not found.");

        await _repository.DeleteAsync(id);
    }
}