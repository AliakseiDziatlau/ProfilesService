using AutoMapper;
using MediatR;
using ProfilesService.Application.Queries.ReceptionistQueries;
using ProfilesService.DataAccess.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Handlers.ReceptionistHandlers;

public class GetAllReceptionistsQueryHandler : IRequestHandler<GetAllReceptionistsQuery, IEnumerable<ReceptionistResponseDto>>
{
    private readonly IReceptionistRepository _repository;
    private readonly IMapper _mapper;

    public GetAllReceptionistsQueryHandler(IReceptionistRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReceptionistResponseDto>> Handle(GetAllReceptionistsQuery request, CancellationToken cancellationToken)
    {
        var receptionists = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ReceptionistResponseDto>>(receptionists);
    }
}