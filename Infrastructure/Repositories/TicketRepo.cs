using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
namespace TheaterBackend.Infrastructure.Repositories;

public class TicketRepo : GenericRepository<Ticket>, ITicketRepo
{
    public TicketRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }
}
