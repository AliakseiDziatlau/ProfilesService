using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById(int id)
    {
        var patient = await _service.GetPatientByIdAsync(id);
        return Ok(patient);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var patients = await _service.GetAllPatientsAsync();
        return Ok(patients);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto dto)
    {
        await _service.CreatePatientAsync(dto);
        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] CreatePatientDto dto)
    {
        await _service.UpdatePatientAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        await _service.DeletePatientAsync(id);
        return NoContent();
    }
}