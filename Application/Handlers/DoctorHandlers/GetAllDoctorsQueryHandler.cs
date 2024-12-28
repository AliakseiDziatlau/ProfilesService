using AutoMapper;
using MediatR;
using ProfilesService.Application.Queries.DoctorQueries;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorResponseDto>>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllDoctorsQueryHandler(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorResponseDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<DoctorResponseDto>>(doctors);
    }
}