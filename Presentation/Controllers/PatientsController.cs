using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.Application.Handlers.PatientHandlers;
using ProfilesService.Application.Queries.PatientQueries;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById(int id)
    {
        var query = new GetPatientByIdQuery { Id = id };
        var patient = await _mediator.Send(query);
        return Ok(patient);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var query = new GetAllPatientsQuery();
        var patients = await _mediator.Send(query);
        return Ok(patients);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command)
    {
        await _mediator.Send(command);
        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientCommand command)
    {
        command.Id = id;
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var command = new DeletePatientCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}