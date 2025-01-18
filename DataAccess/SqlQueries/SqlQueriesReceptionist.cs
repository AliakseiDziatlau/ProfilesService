namespace ProfilesService.DataAccess.SqlQueries;

public static class SqlQueriesReceptionist
{
    public const string _getById = "SELECT * FROM Receptionists WHERE Id = @Id";
    public const string _getByEmail = "SELECT * FROM Receptionists WHERE Email = @Email";
    public const string _getAll = "SELECT * FROM Receptionists";
    public const string _create = @"
            INSERT INTO Receptionists (FirstName, LastName, MiddleName, AccountId, OfficeId, PhoneNumber, Email)
            VALUES (@FirstName, @LastName, @MiddleName, @AccountId, @OfficeId, @PhoneNumber, @Email)";
    public const string _update = @"
            UPDATE Receptionists
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                AccountId = @AccountId,
                OfficeId = @OfficeId,
                PhoneNumber = @PhoneNumber,
                Email = @Email
            WHERE Id = @Id";
    public const string _delete = "DELETE FROM Receptionists WHERE Id = @Id";
}