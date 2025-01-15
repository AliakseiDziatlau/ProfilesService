using MediatR;

namespace ProfilesService.Application.Commands.DoctorCommands;

public class DeleteDoctorCommand : IRequest<bool>
{
    public int Id { get; set; }
}