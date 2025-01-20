using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.Application.Queries.ReceptionistQueries;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceptionistsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceptionistsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReceptionistById(int id)
    {
        var query = new GetReceptionistByIdQuery { Id = id };
        var receptionist = await _mediator.Send(query);
        return (receptionist != null) ? Ok(receptionist) : NotFound();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReceptionists()
    {
        var query = new GetAllReceptionistsQuery();
        var receptionists = await _mediator.Send(query);
        return (receptionists != null && receptionists.Any()) ? Ok(receptionists) : NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReceptionist([FromBody] CreateReceptionistCommand command)
    {
        var result = await _mediator.Send(command);
        return (result) ? StatusCode(201) : BadRequest();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReceptionist(int id, [FromBody] UpdateReceptionistCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return (result) ? NoContent() : NotFound();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceptionist(int id)
    {
        var command = new DeleteReceptionistCommand { Id = id };
        var result = await _mediator.Send(command);
        return (result) ? NoContent() : NotFound();
    }
}