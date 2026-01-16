using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/seats")]
public class SeatController : ControllerBase
{
    private readonly SeatService _service;

    public SeatController(SeatService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create(SeatCreateDTO dto)
        => Ok(await _service.CreateAsync(dto));
}
