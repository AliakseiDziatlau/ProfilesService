using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
{
    private readonly IDoctorRepository _repository;
    private readonly ILogger<DeleteDoctorCommandHandler> _logger;

    public DeleteDoctorCommandHandler(IDoctorRepository repository, ILogger<DeleteDoctorCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling DeleteDoctorCommand for Doctor ID: {DoctorId}", request.Id);
        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor == null)
        {
            _logger.LogWarning("Doctor with ID: {DoctorId} not found.", request.Id);
            return false;
        }

        await _repository.DeleteAsync(request.Id);
        _logger.LogInformation("Successfully deleted Doctor with ID: {DoctorId}", request.Id);
        return true;
    }
}