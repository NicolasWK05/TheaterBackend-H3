using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace TheaterBackend.Infrastructure.Repositories;

public class FilmRepo : GenericRepository<Film>, IFilmRepo
{
    public FilmRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public new async Task<Film> GetByIdAsync(int id)
    {
        var film = await _dbContext.Films.Include(f => f.Screenings).FirstOrDefaultAsync(f => f.Id == id) ?? throw new InvalidOperationException($"Film with id {id} was not found.");
        return film;
    }
}
