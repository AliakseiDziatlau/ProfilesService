using MediatR;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class UpdateReceptionistCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int? AccountId { get; set; }
    public string OfficeId { get; set; }
}