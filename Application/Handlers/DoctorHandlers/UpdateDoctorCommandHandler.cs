using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public UpdateDoctorCommandHandler(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor == null)
            throw new KeyNotFoundException($"Doctor with ID {request.Id} not found.");

        _mapper.Map(request, doctor);
        await _repository.UpdateAsync(doctor);
    }
}