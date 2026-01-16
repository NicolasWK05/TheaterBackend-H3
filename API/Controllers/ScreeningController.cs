using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/screenings")]
public class ScreeningController : ControllerBase
{
    private readonly ScreeningService _service;

    public ScreeningController(ScreeningService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("films/{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _service.GetByFilmId(id));

    [HttpPost]
    public async Task<IActionResult> Create(ScreeningCreateDTO dto)
        => Ok(await _service.CreateAsync(dto));
}
