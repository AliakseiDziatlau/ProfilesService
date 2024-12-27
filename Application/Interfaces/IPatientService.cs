using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Interfaces;

public interface IPatientService
{
    Task<PatientResponseDto> GetPatientByIdAsync(int id);
    Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
    Task CreatePatientAsync(CreatePatientDto dto);
    Task UpdatePatientAsync(int id, CreatePatientDto dto);
    Task DeletePatientAsync(int id);
}