using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class FilmRepo : GenericRepository<Film>, IFilmRepo
{
    public FilmRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
