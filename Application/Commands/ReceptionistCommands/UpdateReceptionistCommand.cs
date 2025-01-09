using MediatR;
using ProfilesService.BusinessLogic.Domain.Entities;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class UpdateReceptionistCommand : BaseProfile, IRequest
{
    public int Id { get; set; }
    public int? AccountId { get; set; }
    public string OfficeId { get; set; }
}