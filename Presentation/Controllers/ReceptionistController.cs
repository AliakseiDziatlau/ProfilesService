using Microsoft.AspNetCore.Mvc;
using ProfilesService.Application.Interfaces;
using ProfilesService.Presentation.DTOs;

namespace ProfilesService.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceptionistController : ControllerBase
{
    private readonly IReceptionistService _service;

    public ReceptionistController(IReceptionistService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReceptionistById(int id)
    {
        var receptionist = await _service.GetReceptionistByIdAsync(id);
        return Ok(receptionist);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReceptionists()
    {
        var receptionists = await _service.GetAllReceptionistsAsync();
        return Ok(receptionists);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReceptionist([FromBody] CreateReceptionistDto dto)
    {
        await _service.CreateReceptionistAsync(dto);
        return StatusCode(201);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReceptionist(int id, [FromBody] CreateReceptionistDto dto)
    {
        await _service.UpdateReceptionistAsync(id, dto);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceptionist(int id)
    {
        await _service.DeleteReceptionistAsync(id);
        return NoContent();
    }
}