using MediatR;

namespace ProfilesService.Application.Commands.PatientCommands;

public class DeletePatientCommand : IRequest
{
    public int Id { get; set; }
}