using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TheaterBackend.Infrastructure.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepo
{
    public PersonRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Person> GetByEmailAsync(string email)
    {
        return await _dbContext.Persons.FirstOrDefaultAsync(p => p.Email == email);
    }
}
