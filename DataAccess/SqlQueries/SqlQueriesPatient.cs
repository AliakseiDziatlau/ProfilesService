namespace ProfilesService.DataAccess.SqlQueries;

public class SqlQueriesPatient
{
    public const string _getById = "SELECT * FROM Patients WHERE Id = @Id";
    public const string _getByEmail = "SELECT * FROM Patients WHERE Email = @Email";
    public const string _getAll = "SELECT * FROM Patients";
    public const string _create = @"
            INSERT INTO Patients (FirstName, LastName, MiddleName, DateOfBirth, IsLinkedToAccount, AccountId, PhoneNumber, Email)
            VALUES (@FirstName, @LastName, @MiddleName, @DateOfBirth, @IsLinkedToAccount, @AccountId, @PhoneNumber, @Email);";
    public const string _update = @"
            UPDATE Patients
            SET FirstName = @FirstName,
                LastName = @LastName,
                MiddleName = @MiddleName,
                DateOfBirth = @DateOfBirth,
                IsLinkedToAccount = @IsLinkedToAccount,
                AccountId = @AccountId,
                PhoneNumber = @PhoneNumber,
                Email = @Email
            WHERE Id = @Id";
    public const string _delete = "DELETE FROM Patients WHERE Id = @Id";
}