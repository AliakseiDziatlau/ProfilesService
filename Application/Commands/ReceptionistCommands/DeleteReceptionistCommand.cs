using MediatR;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class DeleteReceptionistCommand : IRequest<bool>
{
    public int Id { get; set; }
}