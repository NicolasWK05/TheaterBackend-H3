using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;
using TheaterBackend.Application.DTOs;

namespace TheaterBackend.Application.Services;

public class ScreeningService(IScreeningRepo repo, IFilmRepo filmRepo, IScreenRepo screenRepo) : GenericService<Screening>(repo), IScreeningService
{
    public async Task<IEnumerable<ScreeningReadDTO>> GetAllAsync()
            => (await repo.GetAllWithIncludesAsync()).Select(Map);

    public async Task<ScreeningReadDTO> CreateAsync(ScreeningCreateDTO dto)
    {
        var film = await filmRepo.GetByIdAsync(dto.FilmId);
        var screen = await screenRepo.GetByIdAsync(dto.ScreenId);

        var screening = new Screening
        {
            Film = film!,
            Screen = screen!,
            StartTime = dto.StartTime,
            EndTime = dto.StartTime.AddMinutes(film!.Duration)
        };

        await repo.AddAsync(screening);
        return Map(screening);
    }

    private static ScreeningReadDTO Map(Screening s) => new()
    {
        Id = s.Id,
        StartTime = s.StartTime,
        EndTime = s.EndTime,
        FilmId = s.Film.Id,
        FilmTitle = s.Film.Title,
        ScreenId = s.Screen.Id,
        ScreenName = s.Screen.Name
    };

    public async Task<IEnumerable<ScreeningReadDTO>> GetByFilmId(int id)
    {
        var screening = await repo.GetByFilmId(id) ?? throw new InvalidOperationException($"Screening with id {id} was not found.");
        List<ScreeningReadDTO> screenings = new List<ScreeningReadDTO>();
        foreach (var s in screening)
        {
            screenings.Add(Map(s));
        }
        return screenings;
    }
}
