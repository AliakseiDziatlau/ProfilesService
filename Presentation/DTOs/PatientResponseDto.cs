namespace ProfilesService.Presentation.DTOs;

public class PatientResponseDto : BaseDto
{
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public int? AccountId { get; set; }
}