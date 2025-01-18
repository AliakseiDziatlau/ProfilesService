using MediatR;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.PatientHandlers;

public class UpdatePatientPhoneNumberHandler : IRequestHandler<UpdatePatientPhoneNumberCommand>
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientPhoneNumberHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Unit> Handle(UpdatePatientPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByEmailAsync(request.UserEmail);
        if (patient == null)
            throw new Exception($"Patient with ID {request.UserEmail} not found");

        patient.PhoneNumber = request.NewPhoneNumber;
        await _patientRepository.UpdateAsync(patient);

        return Unit.Value;
    }
}