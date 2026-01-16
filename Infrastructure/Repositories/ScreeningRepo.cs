using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace TheaterBackend.Infrastructure.Repositories;

public class ScreeningRepo(DatabaseContext dbContext) : GenericRepository<Screening>(dbContext), IScreeningRepo
{
    public async Task<IEnumerable<Screening>> GetAllWithIncludesAsync()
    {
        return await _dbContext.Screenings
            .Include(s => s.Film)
            .Include(s => s.Screen)
            .ToListAsync();
    }

    public async Task<IEnumerable<Screening>> GetByFilmId(int id)
    {
        return await _dbContext.Screenings
            .Where(s => s.FilmId == id)
            .Include(s => s.Film)
            .Include(s => s.Screen)
            .ToListAsync();
    }

}
