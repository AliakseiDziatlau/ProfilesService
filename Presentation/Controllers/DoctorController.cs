using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _service;

    public DoctorController(IDoctorService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var doctor = await _service.GetDoctorByIdAsync(id);
        return Ok(doctor);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _service.GetAllDoctorsAsync();
        return Ok(doctors);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto dto)
    {
        await _service.CreateDoctorAsync(dto);
        return StatusCode(201);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] CreateDoctorDto dto)
    {
        await _service.UpdateDoctorAsync(id, dto);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        await _service.DeleteDoctorAsync(id);
        return NoContent();
    }
}