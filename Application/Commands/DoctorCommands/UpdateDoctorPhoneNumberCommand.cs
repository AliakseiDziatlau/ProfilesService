using MediatR;
using ProfilesService.Application.Commands.BaseCommands;

namespace ProfilesService.Application.Commands.DoctorCommands;

public class UpdateDoctorPhoneNumberCommand : UpdatePhoneNumberCommand, IRequest { }