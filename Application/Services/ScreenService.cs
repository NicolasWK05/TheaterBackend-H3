using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;
using TheaterBackend.Application.DTOs;

namespace TheaterBackend.Application.Services;

public class ScreenService : GenericService<Screen>
{
    public ScreenService(IScreenRepo repo) : base(repo) { }

    public async Task<IEnumerable<ScreenReadDTO>> GetAllAsync()
    {
        var screens = await Repo.GetAllAsync();
        return screens.Select(MapToReadDTO);
    }

    public async Task<ScreenReadDTO?> GetByIdAsync(int id)
    {
        var screen = await Repo.GetByIdAsync(id);
        return screen is null ? null : MapToReadDTO(screen);
    }

    public async Task<ScreenReadDTO> CreateAsync(ScreenCreateDTO dto)
    {
        var screen = new Screen
        {
            Name = dto.Name,
            Capacity = dto.Capacity,
            RowCount = dto.RowCount,
            ColumnCount = dto.ColumnCount,
            TheaterId = dto.TheaterId
        };

        await Repo.AddAsync(screen);
        return MapToReadDTO(screen);
    }

    public async Task<bool> UpdateAsync(int id, ScreenUpdateDTO dto)
    {
        var screen = await Repo.GetByIdAsync(id);
        if (screen is null) return false;

        screen.Name = dto.Name;
        screen.Capacity = dto.Capacity;

        await Repo.UpdateAsync(screen);
        return true;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        var screen = await Repo.GetByIdAsync(id);
        if (screen is null) return false;

        await Repo.DeleteAsync(screen.Id);
        return true;
    }

    private static ScreenReadDTO MapToReadDTO(Screen screen)
        => new()
        {
            Id = screen.Id,
            Name = screen.Name,
            Capacity = screen.Capacity,
            TheaterId = screen.TheaterId,
            RowCount = screen.RowCount,
            ColumnCount = screen.ColumnCount,
            PremiumSeatCount = screen.PremiumSeatCount
        };
}
