namespace ProfilesService.Presentation.DTOs;

public class CreatePatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public int? AccountId { get; set; }
}