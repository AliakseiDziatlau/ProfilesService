using MediatR;
using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class CreatePatientCommand : BaseProfile, IRequest<bool>
{
    public DateTime DateOfBirth { get; set; }
    public bool IsLinkedToAccount { get; set; }
    public int? AccountId { get; set; }
}