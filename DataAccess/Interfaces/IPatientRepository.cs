using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.DataAccess.Interfaces;

public interface IPatientRepository
{
    Task<Patient> GetByIdAsync(int id);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task CreateAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(int id);
}