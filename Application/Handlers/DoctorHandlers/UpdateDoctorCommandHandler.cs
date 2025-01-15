using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, bool>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateDoctorCommandHandler> _logger;

    public UpdateDoctorCommandHandler(IDoctorRepository repository, IMapper mapper, ILogger<UpdateDoctorCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling UpdateDoctorCommand for Doctor ID: {DoctorId}", request.Id);

        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor == null)
        {
            _logger.LogWarning("Doctor with ID: {DoctorId} not found.", request.Id);
            return false;
        }

        _logger.LogInformation("Doctor with ID: {DoctorId} found. Updating doctor details.", request.Id);
        
        _mapper.Map(request, doctor);
        _logger.LogDebug("Mapped updated details to Doctor: {@Doctor}", doctor);
        await _repository.UpdateAsync(doctor);
        _logger.LogInformation("Successfully updated Doctor with ID: {DoctorId}", doctor.Id);
        return true;
    }
}