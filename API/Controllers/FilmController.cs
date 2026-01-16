using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/films")]
public class FilmController : ControllerBase
{
    private readonly FilmService _filmService;

    public FilmController(FilmService filmService)
    {
        _filmService = filmService;
    }

    // GET /api/films
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilmReadDTO>>> GetAll()
    {
        var films = await _filmService.GetAllAsync();
        return Ok(films);
    }

    // GET /api/films/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<FilmReadDTO>> GetById(int id)
    {
        var film = await _filmService.GetByIdAsync(id);
        if (film is null)
            return NotFound();

        return Ok(film);
    }

    // POST /api/films
    [HttpPost]
    public async Task<ActionResult<FilmReadDTO>> Create(FilmCreateDTO dto)
    {
        var created = await _filmService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created
        );
    }

    // PUT /api/films/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, FilmUpdateDTO dto)
    {
        var updated = await _filmService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE /api/films/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _filmService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
