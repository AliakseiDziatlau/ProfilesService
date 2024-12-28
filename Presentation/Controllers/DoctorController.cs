using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.Application.Interfaces;
using ProfilesService.Application.Queries.DoctorQueries;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var query = new GetDoctorByIdQuery { Id = id };
        var doctor = await _mediator.Send(query);
        return Ok(doctor);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new GetAllDoctorsQuery();
        var doctors = await _mediator.Send(query);
        return Ok(doctors);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(201);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var command = new DeleteDoctorCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}