using AutoMapper;
using MediatR;
using ProfilesService.Application.Queries.PatientQueries;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientResponseDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public GetAllPatientsQueryHandler(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientResponseDto>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        var patients = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientResponseDto>>(patients);
    }
}