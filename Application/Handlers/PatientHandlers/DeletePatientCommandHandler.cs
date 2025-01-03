using MediatR;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _repository;

    public DeletePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {request.Id} not found.");

        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}