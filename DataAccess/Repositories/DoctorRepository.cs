using System.Data;
using Dapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.DataAccess.SqlQueries;

namespace ProfilesService.DataAccess.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly IDbConnection _dbConnection;
    
    public DoctorRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<Doctor> GetByIdAsync(int id)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<Doctor>(SqlQueriesDoctor._getById, new { Id = id });
    }

    public async Task<Doctor> GetByEmailAsync(string email)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<Doctor>(SqlQueriesDoctor._getByEmail, new { Email = email });
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbConnection.QueryAsync<Doctor>(SqlQueriesDoctor._getAll);
    }

    public async Task CreateAsync(Doctor doctor)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesDoctor._create, doctor);
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesDoctor._update, doctor);
    }

    public async Task DeleteAsync(int id)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesDoctor._delete, new { Id = id });
    }
}