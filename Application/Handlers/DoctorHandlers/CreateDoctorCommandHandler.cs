using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.DoctorHandlers;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand>
{
    private readonly IDoctorRepository _repository;
    private readonly IMapper _mapper;

    public CreateDoctorCommandHandler(IDoctorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = _mapper.Map<Doctor>(request);
        await _repository.CreateAsync(doctor);
    }
}