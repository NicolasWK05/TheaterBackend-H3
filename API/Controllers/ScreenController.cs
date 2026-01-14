using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScreenController : ControllerBase
{
    private readonly ScreenService _screenService;

    public ScreenController(ScreenService screenService)
    {
        _screenService = screenService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var screens = _screenService.GetAllAsync();
        return Ok(screens);
    }
}