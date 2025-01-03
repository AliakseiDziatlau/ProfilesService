using MediatR;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class CreateReceptionistCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int? AccountId { get; set; }
    public string OfficeId { get; set; }
}