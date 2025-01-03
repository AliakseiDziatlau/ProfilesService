using System.Data;
using Dapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

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
        string sql = "SELECT * FROM Patients WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<Patient>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        string sql = "SELECT * FROM Patients";
        return await _dbConnection.QueryAsync<Patient>(sql);
    }

    public async Task CreateAsync(Patient patient)
    {
        string sql = @"
            INSERT INTO Patients (FirstName, LastName, MiddleName, DateOfBirth, IsLinkedToAccount, AccountId)
            VALUES (@FirstName, @LastName, @MiddleName, @DateOfBirth, @IsLinkedToAccount, @AccountId)";
        await _dbConnection.ExecuteAsync(sql, patient);
    }

    public async Task UpdateAsync(Patient patient)
    {
        string sql = @"
            UPDATE Patients
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                DateOfBirth = @DateOfBirth,
                IsLinkedToAccount = @IsLinkedToAccount,
                AccountId = @AccountId
            WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, patient);
    }

    public async Task DeleteAsync(int id)
    {
        string sql = "DELETE FROM Patients WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}