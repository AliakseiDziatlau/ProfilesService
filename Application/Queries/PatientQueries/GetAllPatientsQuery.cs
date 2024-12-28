using MediatR;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Queries.PatientQueries;

public class GetAllPatientsQuery : IRequest<IEnumerable<PatientResponseDto>> {}