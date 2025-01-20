using MediatR;
using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class CreateReceptionistCommand : BaseProfile, IRequest<bool>
{
    public int? AccountId { get; set; }
    public string OfficeId { get; set; }
}