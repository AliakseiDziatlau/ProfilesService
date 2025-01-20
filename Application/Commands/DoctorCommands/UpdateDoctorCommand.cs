using MediatR;
using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.Application.Commands.DoctorCommands;

public class UpdateDoctorCommand : BaseProfile, IRequest<bool>
{
    public int Id { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int? AccountId { get; set; }
    public int SpecializationId { get; set; }
    public string OfficeId { get; set; }
    public int CareerStartYear { get; set; }
    public string Status { get; set; }
}