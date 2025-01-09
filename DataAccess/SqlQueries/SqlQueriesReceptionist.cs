namespace ProfilesService.DataAccess.SqlQueries;

public static class SqlQueriesReceptionist
{
    public const string _getById = "SELECT * FROM Receptionists WHERE Id = @Id";
    public const string _getAll = "SELECT * FROM Receptionists";
    public const string _create = @"
            INSERT INTO Receptionists (FirstName, LastName, MiddleName, AccountId, OfficeId)
            VALUES (@FirstName, @LastName, @MiddleName, @AccountId, @OfficeId)";
    public const string _update = @"
            UPDATE Receptionists
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                AccountId = @AccountId,
                OfficeId = @OfficeId
            WHERE Id = @Id";
    public const string _delete = "DELETE FROM Receptionists WHERE Id = @Id";
}