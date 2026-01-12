using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class TheaterRepo : GenericRepository<Theater>, ITheaterRepo
{
    public TheaterRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
