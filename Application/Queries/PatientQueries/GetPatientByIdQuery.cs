using MediatR;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Queries.PatientQueries;

public class GetPatientByIdQuery : IRequest<PatientResponseDto>
{
    public int Id { get; set; }
}