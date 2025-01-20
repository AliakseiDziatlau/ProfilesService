using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.DataAccess.Interfaces;

public interface IDoctorRepository
{
    Task<Doctor> GetByIdAsync(int id);
    Task<Doctor> GetByEmailAsync(string email);
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task CreateAsync(Doctor doctor);
    Task UpdateAsync(Doctor doctor);
    Task DeleteAsync(int id);
}