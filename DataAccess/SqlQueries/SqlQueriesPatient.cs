namespace ProfilesService.DataAccess.SqlQueries;

public class SqlQueriesPatient
{
    public const string _getById = "SELECT * FROM Patients WHERE Id = @Id";
    public const string _getAll = "SELECT * FROM Patients";
    public const string _create = @"
            INSERT INTO Patients (FirstName, LastName, MiddleName, DateOfBirth, IsLinkedToAccount, AccountId)
            VALUES (@FirstName, @LastName, @MiddleName, @DateOfBirth, @IsLinkedToAccount, @AccountId)";
    public const string _update = @"
            UPDATE Patients
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                DateOfBirth = @DateOfBirth,
                IsLinkedToAccount = @IsLinkedToAccount,
                AccountId = @AccountId
            WHERE Id = @Id";
    public const string _delete = "DELETE FROM Patients WHERE Id = @Id";
}