using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.DataAccess.Interfaces;

public interface IReceptionistRepository
{
    Task<Receptionist> GetByIdAsync(int id);
    Task<IEnumerable<Receptionist>> GetAllAsync();
    Task CreateAsync(Receptionist receptionist);
    Task UpdateAsync(Receptionist receptionist);
    Task DeleteAsync(int id);
}