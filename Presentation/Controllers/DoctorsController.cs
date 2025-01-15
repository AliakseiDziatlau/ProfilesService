using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Commands.DoctorCommands;
using ProfilesService.Application.Queries.DoctorQueries;

namespace ProfilesService.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var query = new GetDoctorByIdQuery { Id = id };
        var doctor = await _mediator.Send(query);
        return (doctor != null)?Ok(doctor):NotFound(new { Message = "Doctor not found" });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new GetAllDoctorsQuery();
        var doctors = await _mediator.Send(query);
        return (doctors != null && doctors.Any())?Ok(doctors) : NotFound(new { Message = "No doctors found" });
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command)
    {
        var result = await _mediator.Send(command);
        return (result)?StatusCode(201):BadRequest(new { Message = "Doctor already exists" });
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] UpdateDoctorCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return (result)?NoContent():NotFound(new { Message = $"Doctor with ID {id} not found." });;
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var command = new DeleteDoctorCommand { Id = id };
        var result = await _mediator.Send(command);
        return (result)?NoContent():NotFound(new { Message = $"Doctor with ID {id} not found." });
    }
}