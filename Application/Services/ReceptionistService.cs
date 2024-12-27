using AutoMapper;
using ProfilesService.Application.Interfaces;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Services;

public class ReceptionistService : IReceptionistService
{
    private readonly IReceptionistRepository _repository;
    private readonly IMapper _mapper;
    
    public ReceptionistService(IReceptionistRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReceptionistResponseDto> GetReceptionistByIdAsync(int id)
    {
        var receptionist = await _repository.GetByIdAsync(id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {id} not found.");

        return _mapper.Map<ReceptionistResponseDto>(receptionist);
    }

    public async Task<IEnumerable<ReceptionistResponseDto>> GetAllReceptionistsAsync()
    {
        var receptionists = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ReceptionistResponseDto>>(receptionists);
    }


    public async Task CreateReceptionistAsync(CreateReceptionistDto dto)
    {
        var receptionist = _mapper.Map<Receptionist>(dto);
        await _repository.CreateAsync(receptionist);
    }

    public async Task UpdateReceptionistAsync(int id, CreateReceptionistDto dto)
    {
        var receptionist = await _repository.GetByIdAsync(id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {id} not found.");
        
        _mapper.Map(dto, receptionist);
        await _repository.UpdateAsync(receptionist);
    }

    public async Task DeleteReceptionistAsync(int id)
    {
        var receptionist = await _repository.GetByIdAsync(id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {id} not found.");

        await _repository.DeleteAsync(id);
    }
}