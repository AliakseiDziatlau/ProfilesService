namespace ProfilesService.Presentation.DTOs;

public class CreateReceptionistDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int? AccountId { get; set; }
    public string OfficeId { get; set; }
}