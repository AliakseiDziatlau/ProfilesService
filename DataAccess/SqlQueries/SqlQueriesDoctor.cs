namespace ProfilesService.DataAccess.SqlQueries;

public static class SqlQueriesDoctor
{
    public const string _getById = "SELECT * FROM Doctors WHERE Id = @Id";
    public const string _getByEmail = "SELECT * FROM Doctors WHERE Email = @Email";
    public const string _getAll = "SELECT * FROM Doctors";
    public const string _create = @"
            INSERT INTO Doctors (FirstName, LastName, MiddleName, DateOfBirth, AccountId, SpecializationId, OfficeId, CareerStartYear, Status, PhoneNumber, Email)
            VALUES (@FirstName, @LastName, @MiddleName, @DateOfBirth, @AccountId, @SpecializationId, @OfficeId, @CareerStartYear, @Status, @PhoneNumber, @Email)";
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
                Status = @Status,
                PhoneNumber = @PhoneNumber,
                Email = @Email
            WHERE Id = @Id";
    public const string _delete = "DELETE FROM Doctors WHERE Id = @Id";
}