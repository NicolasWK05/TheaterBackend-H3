using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class SeatRepo : GenericRepository<Seat>, ISeatRepo
{
    public SeatRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
