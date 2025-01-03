using MediatR;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class DeleteReceptionistCommand : IRequest
{
    public int Id { get; set; }
}