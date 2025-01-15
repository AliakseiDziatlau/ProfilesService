using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.BusinessLogic.Domain.Entities;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.ReceptionistHandlers;

public class CreateReceptionistCommandHandler : IRequestHandler<CreateReceptionistCommand, bool>
{
    private readonly IReceptionistRepository _repository;
    private readonly IMapper _mapper;

    public CreateReceptionistCommandHandler(IReceptionistRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var receptionist = _mapper.Map<Receptionist>(request);
            await _repository.CreateAsync(receptionist);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}