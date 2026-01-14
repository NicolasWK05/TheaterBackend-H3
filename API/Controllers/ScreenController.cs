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
        var screens = await _screenService.GetAllAsync();
        return Ok(screens);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] int id)
    {
        await _screenService.DeleteAsync(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Screen screen)
    {
        await _screenService.CreateAsync(screen);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Screen screen)
    {
        await _screenService.UpdateAsync(screen);
        return Ok();
    }
}