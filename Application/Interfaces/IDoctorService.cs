using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Interfaces;

public interface IDoctorService
{
    Task<DoctorResponseDto> GetDoctorByIdAsync(int id);
    Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync();
    Task CreateDoctorAsync(CreateDoctorDto dto);
    Task UpdateDoctorAsync(int id, CreateDoctorDto dto);
    Task DeleteDoctorAsync(int id);
}