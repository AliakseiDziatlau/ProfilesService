using System.Data;
using Dapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.DataAccess.SqlQueries;

namespace ProfilesService.DataAccess.Repositories;

public class ReceptionistRepository : IReceptionistRepository
{
    private readonly IDbConnection _dbConnection;

    public ReceptionistRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    
    public async Task<Receptionist> GetByIdAsync(int id)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<Receptionist>(SqlQueriesReceptionist._getById, new { Id = id });
    }
    
    public async Task<Receptionist> GetByEmailAsync(string email)
    {
        return await _dbConnection.QuerySingleOrDefaultAsync<Receptionist>(SqlQueriesReceptionist._getByEmail, new { Email = email });
    }

    public async Task<IEnumerable<Receptionist>> GetAllAsync()
    {
        return await _dbConnection.QueryAsync<Receptionist>(SqlQueriesReceptionist._getAll);
    }
    
    public async Task CreateAsync(Receptionist receptionist)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesReceptionist._create, receptionist);
    }

    public async Task UpdateAsync(Receptionist receptionist)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesReceptionist._update, receptionist);
    }

    public async Task DeleteAsync(int id)
    {
        await _dbConnection.ExecuteAsync(SqlQueriesReceptionist._delete, new { Id = id });
    }
}