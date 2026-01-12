using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class ShowcaseRepo : GenericRepository<Showcase>, IShowcaseRepo
{
    public ShowcaseRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
