namespace TheaterBackend.Domain.Interfaces;

using TheaterBackend.Domain.Models;

public interface IPersonRepo : IGenericRepo<Person>
{
    Task<Person> GetByEmailAsync(string email);
}
