using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class ScreeningRepo : GenericRepository<Screening>, IScreeningRepo
{
    public ScreeningRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
