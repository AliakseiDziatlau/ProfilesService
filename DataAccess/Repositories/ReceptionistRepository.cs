using System.Data;
using Dapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

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
        string sql = "SELECT * FROM Receptionists WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<Receptionist>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Receptionist>> GetAllAsync()
    {
        string sql = "SELECT * FROM Receptionists";
        return await _dbConnection.QueryAsync<Receptionist>(sql);
    }
    
    public async Task CreateAsync(Receptionist receptionist)
    {
        string sql = @"
            INSERT INTO Receptionists (FirstName, LastName, MiddleName, AccountId, OfficeId)
            VALUES (@FirstName, @LastName, @MiddleName, @AccountId, @OfficeId)";
        await _dbConnection.ExecuteAsync(sql, receptionist);
    }

    public async Task UpdateAsync(Receptionist receptionist)
    {
        string sql = @"
            UPDATE Receptionists
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                AccountId = @AccountId,
                OfficeId = @OfficeId
            WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, receptionist);
    }

    public async Task DeleteAsync(int id)
    {
        string sql = "DELETE FROM Receptionists WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}