using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateDoctorCommandHandler> _logger;

    public CreateDoctorCommandHandler(IDoctorRepository repository, IMapper mapper, ILogger<CreateDoctorCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting CreateDoctorCommandHandler for Doctor: {FirstName} {LastName}", request.FirstName, request.LastName);
        var doctor = _mapper.Map<Doctor>(request);
        _logger.LogDebug("Mapped Doctor: {@Doctor}", doctor);
        await _repository.CreateAsync(doctor);
        _logger.LogInformation("Doctor successfully created with ID: {DoctorId}", doctor.Id);
        return Unit.Value;
    }
}