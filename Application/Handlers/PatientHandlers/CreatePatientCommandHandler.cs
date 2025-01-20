using AutoMapper;
using MediatR;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, bool>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public CreatePatientCommandHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var patient = _mapper.Map<Patient>(request);
            await _repository.CreateAsync(patient);
            return true;
        }
        catch (Exception ex)
        {
            return false; 
        }
        // var patient = _mapper.Map<Patient>(request);
        // await _repository.CreateAsync(patient);
        // return Unit.Value;
    }
}