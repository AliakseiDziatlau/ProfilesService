using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePatientCommandHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {request.Id} not found.");

        _mapper.Map(request, patient);
        await _repository.UpdateAsync(patient);
        return Unit.Value;
    }
}