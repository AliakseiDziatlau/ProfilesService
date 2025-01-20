using AutoMapper;
using MediatR;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.DataAccess.Interfaces;

namespace ProfilesService.Application.Handlers.ReceptionistHandlers;

public class UpdateReceptionistCommandHandler : IRequestHandler<UpdateReceptionistCommand, bool>
{
    private readonly IReceptionistRepository _repository;
    private readonly IMapper _mapper;

    public UpdateReceptionistCommandHandler(IReceptionistRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateReceptionistCommand request, CancellationToken cancellationToken)
    {
        var receptionist = await _repository.GetByIdAsync(request.Id);
        if (receptionist == null)
            return false;

        _mapper.Map(request, receptionist);
        await _repository.UpdateAsync(receptionist);
        return true;
    }
}