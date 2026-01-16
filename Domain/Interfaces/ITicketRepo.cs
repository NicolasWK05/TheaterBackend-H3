namespace TheaterBackend.Domain.Interfaces;

using TheaterBackend.Domain.Models;

public interface ITicketRepo : IGenericRepo<Ticket>
{
    Task<IEnumerable<Ticket>> GetByPersonAsync(int personId);
}
