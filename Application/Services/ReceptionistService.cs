using ProfilesService.Application.Interfaces;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Services;

public class ReceptionistService : IReceptionistService
{
    private readonly IReceptionistRepository _repository;
    public ReceptionistService(IReceptionistRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReceptionistResponseDto> GetReceptionistByIdAsync(int id)
    {
        var receptionist = await _repository.GetByIdAsync(id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {id} not found.");

        return new ReceptionistResponseDto
        {
            Id = receptionist.Id,
            FirstName = receptionist.FirstName,
            LastName = receptionist.LastName,
            MiddleName = receptionist.MiddleName,
            AccountId = receptionist.AccountId,
            OfficeId = receptionist.OfficeId
        };
    }

    public async Task<IEnumerable<ReceptionistResponseDto>> GetAllReceptionistsAsync()
    {
        var receptionists = await _repository.GetAllAsync();
        return receptionists.Select(r => new ReceptionistResponseDto
        {
            Id = r.Id,
            FirstName = r.FirstName,
            LastName = r.LastName,
            MiddleName = r.MiddleName,
            AccountId = r.AccountId,
            OfficeId = r.OfficeId
        });
    }


    public async Task CreateReceptionistAsync(CreateReceptionistDto dto)
    {
        var receptionist = new Receptionist
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            AccountId = dto.AccountId,
            OfficeId = dto.OfficeId
        };

        await _repository.CreateAsync(receptionist);
    }

    public async Task UpdateReceptionistAsync(int id, CreateReceptionistDto dto)
    {
        var receptionist = await _repository.GetByIdAsync(id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {id} not found.");

        receptionist.FirstName = dto.FirstName;
        receptionist.LastName = dto.LastName;
        receptionist.MiddleName = dto.MiddleName;
        receptionist.AccountId = dto.AccountId;
        receptionist.OfficeId = dto.OfficeId;

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