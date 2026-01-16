using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Interfaces;
using TheaterBackend.Application.Services;
using TheaterBackend.Domain.Models;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IJwtTokenService _jwtService;
    private readonly IPasswordHasher _passwordHasher = new PasswordHasher();

    public AuthController(
        IPersonService personService,
        IJwtTokenService jwtService)
    {
        _personService = personService;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var existingUser = await _personService.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            return BadRequest("Email already in use");

        var person = new Person
        {
            Name = dto.Name,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash = _passwordHasher.Hash(dto.Password)
        };

        await _personService.CreateAsync(person);

        var token = _jwtService.GenerateToken(person.Email, "User");

        return Ok(new AuthResponseDto
        {
            Email = person.Email,
            Token = token
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var person = await _personService.GetByEmailAsync(dto.Email);

        if (person == null || !_passwordHasher.Verify(dto.Password, person.PasswordHash))
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateToken(person.Email, "User");

        return Ok(new AuthResponseDto
        {
            Email = person.Email,
            Token = token
        });
    }
}
