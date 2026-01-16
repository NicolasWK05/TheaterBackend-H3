using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/screens")]
public class ScreenController : ControllerBase
{
    private readonly ScreenService _screenService;

    public ScreenController(ScreenService screenService)
    {
        _screenService = screenService;
    }

    // GET /api/screens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScreenReadDTO>>> GetAll()
    {
        var screens = await _screenService.GetAllAsync();
        return Ok(screens);
    }

    // GET /api/screens/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ScreenReadDTO>> GetById(int id)
    {
        var screen = await _screenService.GetByIdAsync(id);
        if (screen is null)
            return NotFound();

        return Ok(screen);
    }

    // POST /api/screens
    [HttpPost]
    public async Task<ActionResult<ScreenReadDTO>> Create(ScreenCreateDTO dto)
    {
        var created = await _screenService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created
        );
    }

    // PUT /api/screens/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ScreenUpdateDTO dto)
    {
        var updated = await _screenService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE /api/screens/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _screenService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
