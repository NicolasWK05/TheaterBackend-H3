namespace TheaterBackend.Application.Services;

using TheaterBackend.Application.DTOs;
using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;

public class PersonService(IPersonRepo repo) : GenericService<Person>(repo), IPersonService
{
    public async Task CreateAsync(PersonCreateDTO person)
    {
        var _hasher = new PasswordHasher();
        var hashedPassword = _hasher.Hash(person.Password);
        var personEntity = new Person
        {
            Email = person.Email,
            Name = person.Name,
            PasswordHash = hashedPassword,
            PhoneNumber = person.PhoneNumber
        };
        await repo.AddAsync(personEntity);
    }

    public async Task<PersonDTO> GetByIdAsync(int id)
    {
        var personEntity = await repo.GetByIdAsync(id) ?? throw new Exception("Person not found");
        var personDTO = new PersonDTO
        {
            Id = personEntity.Id,
            Email = personEntity.Email,
            Name = personEntity.Name,
            PhoneNumber = personEntity.PhoneNumber
        };

        return personDTO;
    }

    public async Task UpdateAsync(PersonUpdateDTO person)
    {
        var personEntity = await repo.GetByIdAsync(person.Id);
        if (personEntity == null)
            throw new Exception("Person not found");

        personEntity.Email = person.Email;
        personEntity.Name = person.Name;
        personEntity.PhoneNumber = person.PhoneNumber;

        await repo.UpdateAsync(personEntity);
    }

    public async Task ChangePasswordAsync(PersonChangePasswordDTO person)
    {
        var personEntity = await repo.GetByIdAsync(person.Id);
        if (personEntity == null)
            throw new Exception("Person not found");

        var _hasher = new PasswordHasher();
        var hashedPassword = _hasher.Hash(person.NewPassword);

        personEntity.PasswordHash = hashedPassword;

        await repo.UpdateAsync(personEntity);
    }

    public async Task<PersonDTO?> GetByEmailAsync(string email)
    {
        var personEntity = await repo.GetByEmailAsync(email);
        if (personEntity == null)
            return null;

        var personDTO = new PersonDTO
        {
            Id = personEntity.Id,
            Email = personEntity.Email,
            Name = personEntity.Name,
            PhoneNumber = personEntity.PhoneNumber,
            PasswordHash = personEntity.PasswordHash
        };

        return personDTO;
    }
}
