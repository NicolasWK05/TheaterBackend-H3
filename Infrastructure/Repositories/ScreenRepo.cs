using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class ScreenRepo : GenericRepository<Screen>, IScreenRepo
{
    public ScreenRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
