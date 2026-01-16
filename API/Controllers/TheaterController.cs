using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/theaters")]
public class TheaterController : ControllerBase
{
    private readonly TheaterService _theaterService;

    public TheaterController(TheaterService theaterService)
    {
        _theaterService = theaterService;
    }

    // GET /api/theaters
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TheaterReadDTO>>> GetAll()
    {
        var theaters = await _theaterService.GetAllAsync();
        return Ok(theaters);
    }

    // GET /api/theaters/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TheaterReadDTO>> GetById(int id)
    {
        var theater = await _theaterService.GetByIdAsync(id);
        if (theater is null)
            return NotFound();

        return Ok(theater);
    }

    // POST /api/theaters
    [HttpPost]
    public async Task<ActionResult<TheaterReadDTO>> Create(TheaterCreateDTO dto)
    {
        var created = await _theaterService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created
        );
    }

    // PUT /api/theaters/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, TheaterUpdateDTO dto)
    {
        var updated = await _theaterService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE /api/theaters/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _theaterService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
