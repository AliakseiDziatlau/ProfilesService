using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, bool>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public UpdatePatientCommandHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);
        if (patient == null)
            return false;

        _mapper.Map(request, patient);
        await _repository.UpdateAsync(patient);
        return true;
    }
}