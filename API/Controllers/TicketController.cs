using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Services;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/tickets")]
[Authorize] // Require JWT authentication for all actions
public class TicketController : ControllerBase
{
    private readonly TicketService _service;

    public TicketController(TicketService service) => _service = service;

    // POST: api/tickets
    [HttpPost]
    public async Task<IActionResult> Buy([FromBody] TicketCreateDTO dto)
    {
        // Get the personId from the JWT claims
        var personIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(personIdClaim) || !int.TryParse(personIdClaim, out int personId))
        {
            return Unauthorized("Invalid token: person ID not found.");
        }

        var ticket = await _service.CreateAsync(personId, dto);
        return Ok(ticket);
    }

    // GET: api/tickets/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _service.GetByIdAsync(id);
        if (ticket == null)
            return NotFound();
        return Ok(ticket);
    }

    // GET: api/tickets/me
    [HttpGet("me")]
    public async Task<IActionResult> GetMyTickets()
    {
        // Read personId from JWT
        var personIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(personIdClaim) || !int.TryParse(personIdClaim, out int personId))
        {
            return Unauthorized("Invalid token: person ID not found.");
        }

        var tickets = await _service.GetByPersonAsync(personId);
        return Ok(tickets);
    }
}
