namespace ProfilesService.BusinessLogic.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public int? AccountId { get; set; }
}