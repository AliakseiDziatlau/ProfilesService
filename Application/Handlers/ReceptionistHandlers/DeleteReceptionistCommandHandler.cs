using MediatR;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.ReceptionistHandlers;

public class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommand>
{
    private readonly IReceptionistRepository _repository;

    public DeleteReceptionistCommandHandler(IReceptionistRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = await _repository.GetByIdAsync(request.Id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {request.Id} not found.");

        await _repository.DeleteAsync(request.Id);
    }
}