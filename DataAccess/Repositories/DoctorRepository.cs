using System.Data;
using Dapper;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

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
        string sql = "SELECT * FROM Doctors WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<Doctor>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        string sql = "SELECT * FROM Doctors";
        return await _dbConnection.QueryAsync<Doctor>(sql);
    }

    public async Task CreateAsync(Doctor doctor)
    {
        string sql = @"
            INSERT INTO Doctors (FirstName, LastName, MiddleName, DateOfBirth, AccountId, SpecializationId, OfficeId, CareerStartYear, Status)
            VALUES (@FirstName, @LastName, @MiddleName, @DateOfBirth, @AccountId, @SpecializationId, @OfficeId, @CareerStartYear, @Status)";
        await _dbConnection.ExecuteAsync(sql, doctor);
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        string sql = @"
            UPDATE Doctors
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                DateOfBirth = @DateOfBirth,
                AccountId = @AccountId,
                SpecializationId = @SpecializationId,
                OfficeId = @OfficeId,
                CareerStartYear = @CareerStartYear,
                Status = @Status
            WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, doctor);
    }

    public async Task DeleteAsync(int id)
    {
        string sql = "DELETE FROM Doctors WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}