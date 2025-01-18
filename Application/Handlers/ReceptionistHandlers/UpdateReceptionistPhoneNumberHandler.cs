using MediatR;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.ReceptionistHandlers;

public class UpdateReceptionistPhoneNumberHandler : IRequestHandler<UpdateReceptionistPhoneNumberCommand>
{
    private readonly IReceptionistRepository _receptionistRepository;

    public UpdateReceptionistPhoneNumberHandler(IReceptionistRepository receptionistRepository)
    {
        _receptionistRepository = receptionistRepository;
    }

    public async Task<Unit> Handle(UpdateReceptionistPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var receptionist = await _receptionistRepository.GetByEmailAsync(request.UserEmail);
        if (receptionist == null)
            throw new Exception($"Patient with ID {request.UserEmail} not found");

        receptionist.PhoneNumber = request.NewPhoneNumber;
        await _receptionistRepository.UpdateAsync(receptionist);

        return Unit.Value;
    }
}