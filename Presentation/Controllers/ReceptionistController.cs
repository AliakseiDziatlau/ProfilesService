using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Commands.ReceptionistCommands;
using ProfilesService.Application.Queries.ReceptionistQueries;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceptionistController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceptionistController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReceptionistById(int id)
    {
        var query = new GetReceptionistByIdQuery { Id = id };
        var receptionist = await _mediator.Send(query);
        return Ok(receptionist);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReceptionists()
    {
        var query = new GetAllReceptionistsQuery();
        var receptionists = await _mediator.Send(query);
        return Ok(receptionists);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReceptionist([FromBody] CreateReceptionistCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(201);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReceptionist(int id, [FromBody] UpdateReceptionistCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceptionist(int id)
    {
        var command = new DeleteReceptionistCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}