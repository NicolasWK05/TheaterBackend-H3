using TheaterBackend.Domain.Models;
using TheaterBackend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace TheaterBackend.Infrastructure.Repositories;

public class TicketRepo : GenericRepository<Ticket>, ITicketRepo
{
    public TicketRepo(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Ticket>> GetByPersonAsync(int personId)
    {
        return await _dbContext.Tickets.Where(t => t.PersonId == personId).ToListAsync();
    }
}
