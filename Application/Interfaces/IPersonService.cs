using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheaterBackend.Application.DTOs;
using TheaterBackend.Domain.Models;

namespace TheaterBackend.Application.Interfaces;

public interface IPersonService : IGenericService<Person>
{
    Task<PersonDTO> GetByIdAsync(int id);
    Task CreateAsync(PersonCreateDTO person);
    Task UpdateAsync(PersonUpdateDTO person);
    Task ChangePasswordAsync(PersonChangePasswordDTO person);
}
