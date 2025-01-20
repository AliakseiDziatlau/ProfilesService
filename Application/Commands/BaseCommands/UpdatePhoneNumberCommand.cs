namespace ProfilesService.Application.Commands.BaseCommands;

public class UpdatePhoneNumberCommand
{
    public string UserEmail { get; set; }
    public string NewPhoneNumber { get; set; }
}