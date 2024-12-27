namespace ProfilesService.Presentation.DTOs;

public class CreateDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int? AccountId { get; set; }
    public int SpecializationId { get; set; }
    public string OfficeId { get; set; }
    public int CareerStartYear { get; set; }
    public string Status { get; set; }
}