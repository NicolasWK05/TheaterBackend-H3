using Microsoft.AspNetCore.Mvc;
using TheaterBackend.Application.Services;
using TheaterBackend.Domain.Models;

namespace TheaterBackend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(PersonService personService)
    {
        _personService = personService;
    }

    // GET api/person
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var persons = await _personService.GetAllAsync();
        return Ok(persons);
    }

    // GET api/person/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var person = await _personService.GetByIdAsync(id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    // POST api/person
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Person person)
    {
        await _personService.CreateAsync(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    // PUT api/person/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Person person)
    {
        if (id != person.Id)
            return BadRequest("ID mismatch");

        await _personService.UpdateAsync(person);
        return NoContent();
    }

    // DELETE api/person/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _personService.DeleteAsync(id);
        return NoContent();
    }
}
