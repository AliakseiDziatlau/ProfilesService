using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Interfaces;

public interface IReceptionistService
{
    Task<ReceptionistResponseDto> GetReceptionistByIdAsync(int id);
    Task<IEnumerable<ReceptionistResponseDto>> GetAllReceptionistsAsync();
    Task CreateReceptionistAsync(CreateReceptionistDto dto);
    Task UpdateReceptionistAsync(int id, CreateReceptionistDto dto);
    Task DeleteReceptionistAsync(int id);
}