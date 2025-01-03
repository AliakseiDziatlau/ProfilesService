using AutoMapper;
using MediatR;
using ProfilesService.Application.Queries.PatientQueries;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientResponseDto>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetPatientByIdQueryHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientResponseDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repository.GetByIdAsync(request.Id);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with ID {request.Id} not found.");

        return _mapper.Map<PatientResponseDto>(patient);
    }
}