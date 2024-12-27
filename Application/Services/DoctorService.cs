using AutoMapper;
using ProfilesService.Application.Interfaces;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<DoctorResponseDto> GetDoctorByIdAsync(int id)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");
        
        return _mapper.Map<DoctorResponseDto>(doctor);
    }

    public async Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync()
    {
        var doctors = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<DoctorResponseDto>>(doctors);
    }

    public async Task CreateDoctorAsync(CreateDoctorDto dto)
    {
        var doctor = _mapper.Map<Doctor>(dto);
        await _repository.CreateAsync(doctor);
    }


    public async Task UpdateDoctorAsync(int id, CreateDoctorDto dto)
    {
        var doctor = await _repository.GetByIdAsync(id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");

        _mapper.Map(dto, doctor);
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