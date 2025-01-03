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
    private readonly ILogger<GetAllDoctorsQueryHandler> _logger;

    public GetAllDoctorsQueryHandler(IDoctorRepository repository, IMapper mapper, ILogger<GetAllDoctorsQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<DoctorResponseDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetAllDoctorsQuery");
        
        var doctors = await _repository.GetAllAsync();
        _logger.LogInformation("Successfully retrieved {Count} doctors.", doctors.Count());
        var response = _mapper.Map<IEnumerable<DoctorResponseDto>>(doctors);
        _logger.LogDebug("Mapped Doctors: {@Response}", response);

        return response;
    }
}