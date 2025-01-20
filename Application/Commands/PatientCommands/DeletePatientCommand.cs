using MediatR;

namespace ProfilesService.Application.Commands.PatientCommands;

public class DeletePatientCommand : IRequest<bool>
{
    public int Id { get; set; }
}