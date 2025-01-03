using MediatR;

namespace ProfilesService.Application.Commands.PatientCommands;

public class UpdatePatientCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public int? AccountId { get; set; }
}