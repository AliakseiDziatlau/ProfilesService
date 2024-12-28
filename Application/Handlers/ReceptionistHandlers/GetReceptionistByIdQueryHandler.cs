using AutoMapper;
using MediatR;
using ProfilesService.Application.Queries.ReceptionistQueries;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Handlers.ReceptionistHandlers;

public class GetReceptionistByIdQueryHandler : IRequestHandler<GetReceptionistByIdQuery, ReceptionistResponseDto>
{
    private readonly IReceptionistRepository _repository;
    private readonly IMapper _mapper;

    public GetReceptionistByIdQueryHandler(IReceptionistRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReceptionistResponseDto> Handle(GetReceptionistByIdQuery request, CancellationToken cancellationToken)
    {
        var receptionist = await _repository.GetByIdAsync(request.Id);
        if (receptionist == null)
            throw new KeyNotFoundException($"Receptionist with ID {request.Id} not found.");

        return _mapper.Map<ReceptionistResponseDto>(receptionist);
    }
}