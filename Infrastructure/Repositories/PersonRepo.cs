using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;

namespace TheaterBackend.Infrastructure.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepo
{
    public PersonRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
