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
    private readonly ILogger<GetDoctorByIdQueryHandler> _logger;

    public GetDoctorByIdQueryHandler(IDoctorRepository repository, IMapper mapper, ILogger<GetDoctorByIdQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<DoctorResponseDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling GetDoctorByIdQuery for Doctor ID: {DoctorId}", request.Id);
        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor == null)
        {
            _logger.LogWarning("Doctor with ID: {DoctorId} not found.", request.Id);
            throw new KeyNotFoundException($"Doctor with ID {request.Id} not found.");
        }
        _logger.LogInformation("Doctor with ID: {DoctorId} found. Mapping to DoctorResponseDto.", request.Id);
        
        var response = _mapper.Map<DoctorResponseDto>(doctor);
        _logger.LogDebug("Mapped DoctorResponseDto: {@Response}", response);
        return response;
    }
}