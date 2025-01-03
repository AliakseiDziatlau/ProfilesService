using MediatR;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Queries.ReceptionistQueries;

public class GetAllReceptionistsQuery : IRequest<IEnumerable<ReceptionistResponseDto>> { }