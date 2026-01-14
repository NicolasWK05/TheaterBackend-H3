using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;
using TheaterBackend.Domain.Models;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TheaterController : ControllerBase
{
    private readonly TheaterService _theaterService;

    public TheaterController(TheaterService theaterService)
    {
        _theaterService = theaterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var theaters = await _theaterService.GetAllAsync();
        return Ok(theaters);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var theater = await _theaterService.GetByIdAsync(id);

        if (theater == null)
            return NotFound();

        return Ok(theater);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Theater theater)
    {
        await _theaterService.CreateAsync(theater);
        return CreatedAtAction(nameof(GetById), theater.Id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Theater theater)
    {
        if (id != theater.Id)
            return BadRequest("ID mismatch");

        await _theaterService.UpdateAsync(theater);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _theaterService.DeleteAsync(id);
        return NoContent();
    }
}
