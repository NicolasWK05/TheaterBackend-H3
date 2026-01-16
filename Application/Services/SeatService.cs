using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;
using TheaterBackend.Application.DTOs;

namespace TheaterBackend.Application.Services;

public class SeatService(ISeatRepo repo) : GenericService<Seat>(repo)
{
    public new async Task<IEnumerable<SeatReadDTO>> GetAllAsync()
        => (await Repo.GetAllAsync()).Select(Map);

    public async Task<SeatReadDTO> CreateAsync(SeatCreateDTO dto)
    {
        var seat = new Seat
        {
            RowNumber = dto.RowNumber,
            ColumnNumber = dto.ColumnNumber,
            IsPremium = dto.IsPremium,
            IsAvailable = true
        };

        await Repo.AddAsync(seat);
        return Map(seat);
    }

    private static SeatReadDTO Map(Seat s) => new()
    {
        Id = s.Id,
        RowNumber = s.RowNumber,
        ColumnNumber = s.ColumnNumber,
        IsPremium = s.IsPremium,
        IsAvailable = s.IsAvailable
    };
}
