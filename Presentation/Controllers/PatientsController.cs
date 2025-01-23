using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Commands.PatientCommands;
using ProfilesService.Application.Handlers.PatientHandlers;
using ProfilesService.Application.Queries.PatientQueries;
using ProfilesService.Presentation.Attributes;
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
        return (patient != null) ? Ok(patient) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var query = new GetAllPatientsQuery();
        var patients = await _mediator.Send(query);
        return (patients != null && patients.Any()) ? Ok(patients) : NotFound();
    }

    [HttpPost]
    [OnlyForReceptionist]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientCommand command)
    {
        var result = await _mediator.Send(command);
        return (result)?StatusCode(201):BadRequest();
    }

    [HttpPut("{id}")]
    [OnlyForReceptionist]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return (result)?NoContent():NotFound();
    }

    [HttpDelete("{id}")]
    [OnlyForReceptionist]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var command = new DeletePatientCommand { Id = id };
        var result = await _mediator.Send(command);
        return (result)?NoContent():NotFound();
    }
}