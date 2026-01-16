using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace TheaterBackend.Infrastructure.Repositories;

public class TheaterRepo : GenericRepository<Theater>, ITheaterRepo
{
    public TheaterRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Theater>> GetAllAsync()
    {
        var theaters = await _dbContext.Theaters.Include(t => t.Screens).ToListAsync();
        return theaters;
    }
}
