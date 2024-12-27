using AutoMapper;
using ProfilesService.Application.Interfaces;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<PatientResponseDto> GetPatientByIdAsync(int id)
    {
        var patient = await _repository.GetByIdAsync(id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {id} not found.");
        return _mapper.Map<PatientResponseDto>(patient);
    }

    public async Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync()
    {
        var patients = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientResponseDto>>(patients);
    }

    public async Task CreatePatientAsync(CreatePatientDto dto)
    {
        var patient = _mapper.Map<Patient>(dto);
        await _repository.CreateAsync(patient);
    }

    public async Task UpdatePatientAsync(int id, CreatePatientDto dto)
    {
        var patient = await _repository.GetByIdAsync(id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {id} not found.");
        
        _mapper.Map(dto, patient);
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