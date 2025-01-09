namespace ProfilesService.DataAccess.SqlQueries;

public static class SqlQueriesDoctor
{
    public const string _getById = "SELECT * FROM Doctors WHERE Id = @Id";
    public const string _getAll = "SELECT * FROM Doctors";
    public const string _create = @"
            INSERT INTO Doctors (FirstName, LastName, MiddleName, DateOfBirth, AccountId, SpecializationId, OfficeId, CareerStartYear, Status)
            VALUES (@FirstName, @LastName, @MiddleName, @DateOfBirth, @AccountId, @SpecializationId, @OfficeId, @CareerStartYear, @Status)";
    public const string _update = @"
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
    public const string _delete = "DELETE FROM Doctors WHERE Id = @Id";
}