using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;
using TheaterBackend.Application.DTOs;

namespace TheaterBackend.Application.Services;

public class TheaterService : GenericService<Theater>
{
    public TheaterService(ITheaterRepo repo) : base(repo) { }

    public async Task<IEnumerable<TheaterReadDTO>> GetAllAsync()
    {
        var theaters = await Repo.GetAllAsync();
        return theaters.Select(MapToReadDTO);
    }

    public new async Task<TheaterReadDTO?> GetByIdAsync(int id)
    {
        var theater = await Repo.GetByIdAsync(id);
        return theater is null ? null : MapToReadDTO(theater);
    }

    public async Task<TheaterReadDTO> CreateAsync(TheaterCreateDTO dto)
    {
        var theater = new Theater
        {
            Name = dto.Name,
            Address = dto.Address
        };

        await Repo.AddAsync(theater);
        return MapToReadDTO(theater);
    }

    public async Task<bool> UpdateAsync(int id, TheaterUpdateDTO dto)
    {
        var theater = await Repo.GetByIdAsync(id);
        if (theater is null) return false;

        theater.Name = dto.Name;
        theater.Address = dto.Address;

        await Repo.UpdateAsync(theater);
        return true;
    }

    public new async Task<bool> DeleteAsync(int id)
    {
        var theater = await Repo.GetByIdAsync(id);
        if (theater is null) return false;

        await Repo.DeleteAsync(theater.Id);
        return true;
    }

    private static TheaterReadDTO MapToReadDTO(Theater theater)
        => new()
        {
            Id = theater.Id,
            Name = theater.Name,
            Address = theater.Address,
            Screens = theater.Screens.Select(s => new ScreenSummaryDTO
            {
                Id = s.Id,
                Name = s.Name,
                Capacity = s.Capacity
            })
        };
}
