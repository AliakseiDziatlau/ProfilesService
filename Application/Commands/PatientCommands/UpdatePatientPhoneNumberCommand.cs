using MediatR;
using ProfilesService.Application.Commands.BaseCommands;

namespace ProfilesService.Application.Commands.PatientCommands;

public class UpdatePatientPhoneNumberCommand : UpdatePhoneNumberCommand, IRequest { }