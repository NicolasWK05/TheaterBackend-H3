namespace TheaterBackend.Domain.Interfaces;

using TheaterBackend.Domain.Models;

public interface IScreeningRepo : IGenericRepo<Screening>
{
    Task<IEnumerable<Screening>> GetAllWithIncludesAsync();
    Task<IEnumerable<Screening>> GetByFilmId(int id);
}
