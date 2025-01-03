using MediatR;

namespace ProfilesService.Application.Commands.DoctorCommands;

public class DeleteDoctorCommand : IRequest
{
    public int Id { get; set; }
}