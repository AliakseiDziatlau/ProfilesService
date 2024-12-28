using MediatR;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Queries.ReceptionistQueries;

public class GetReceptionistByIdQuery : IRequest<ReceptionistResponseDto>
{
    public int Id { get; set; }
}