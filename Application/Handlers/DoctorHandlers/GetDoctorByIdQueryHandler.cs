using AutoMapper;
using MediatR;
using ProfilesService.Application.Queries.DoctorQueries;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorResponseDto>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public GetDoctorByIdQueryHandler(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoctorResponseDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {request.Id} not found.");

        return _mapper.Map<DoctorResponseDto>(doctor);
    }
}