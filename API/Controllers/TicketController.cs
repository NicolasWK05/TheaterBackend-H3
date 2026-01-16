using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly TicketService _service;

    public TicketController(TicketService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Buy(TicketCreateDTO dto)
    {
        // TEMP: replace with JWT later
        int personId = 1;

        return Ok(await _service.CreateAsync(personId, dto));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("user/{personId}")]
    public async Task<IActionResult> GetByPersonId(int personId)
    {
        return Ok(await _service.GetByPersonAsync(personId));
    }

}
