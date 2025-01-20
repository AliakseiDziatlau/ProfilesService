using MediatR;
using ProfilesService.Application.Commands.BaseCommands;

namespace ProfilesService.Application.Commands.ReceptionistCommands;

public class UpdateReceptionistPhoneNumberCommand : UpdatePhoneNumberCommand, IRequest { }