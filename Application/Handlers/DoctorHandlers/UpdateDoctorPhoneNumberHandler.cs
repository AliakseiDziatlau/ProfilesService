using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class UpdateDoctorPhoneNumberHandler : IRequestHandler<UpdateDoctorPhoneNumberCommand>
{
    private readonly IDoctorRepository _doctorRepository;

    public UpdateDoctorPhoneNumberHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Unit> Handle(UpdateDoctorPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorRepository.GetByEmailAsync(request.UserEmail);
        if (doctor == null)
            throw new Exception($"Patient with ID {request.UserEmail} not found");

        doctor.PhoneNumber = request.NewPhoneNumber;
        await _doctorRepository.UpdateAsync(doctor);

        return Unit.Value;
    }
}