using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDoctorRepository _repository;

    public DeleteDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {request.Id} not found.");

        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}