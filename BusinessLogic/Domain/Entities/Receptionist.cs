namespace ProfilesService.BusinessLogic.Domain.Entities;

public class Receptionist : BaseProfile
{
    public int Id { get; set; }

    public int? AccountId { get; set; }
    public string OfficeId { get; set; }
}