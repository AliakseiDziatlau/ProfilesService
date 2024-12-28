using MediatR;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Application.Queries.DoctorQueries;

public class GetAllDoctorsQuery : IRequest<IEnumerable<DoctorResponseDto>> {}