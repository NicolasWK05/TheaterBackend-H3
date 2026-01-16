using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/showcase")]
public class ShowcaseController : ControllerBase
{
    private readonly ShowcaseService _service;

    public ShowcaseController(ShowcaseService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAsync());
}
