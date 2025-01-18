using System.Data;
using Dapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.DataAccess.SqlQueries;

namespace ProfilesService.DataAccess.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly IDbConnection _dbConnection;

    public PatientRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<Patient> GetByIdAsync(int id)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<Patient>(SqlQueriesPatient._getById, new { Id = id });
    }
    
    public async Task<Patient> GetByEmailAsync(string email)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<Patient>(SqlQueriesPatient._getByEmail, new { Email = email });
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _dbConnection.QueryAsync<Patient>(SqlQueriesPatient._getAll, new { Id = 0 });
    }

    public async Task CreateAsync(Patient patient)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesPatient._create, patient);
    }

    public async Task UpdateAsync(Patient patient)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesPatient._update, patient);
    }

    public async Task DeleteAsync(int id)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesPatient._delete, new { Id = id });
    }
}