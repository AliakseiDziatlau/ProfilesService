using MediatR;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Queries.DoctorQueries;

public class GetDoctorByIdQuery : IRequest<DoctorResponseDto>
{
    public int Id { get; set; }
}