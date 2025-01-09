namespace ProfilesService.BusinessLogic.Domain.Entities;

public class Patient : BaseProfile
{
    public int Id { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public int? AccountId { get; set; }
}