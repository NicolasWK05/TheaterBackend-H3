using TheaterBackend.Application.DTOs;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;

namespace TheaterBackend.Application.Services;

public class FilmService(IFilmRepo repo) : GenericService<Film>(repo)
{
    public new async Task<IEnumerable<FilmReadDTO>> GetAllAsync()
    {
        var films = await Repo.GetAllAsync();
        return films.Select(MapToReadDTO);
    }

    public new async Task<FilmReadDTO?> GetByIdAsync(int id)
    {
        var film = await repo.GetByIdAsync(id);
        return film is null ? null : MapToReadDTO(film);
    }

    public async Task<FilmReadDTO> CreateAsync(FilmCreateDTO dto)
    {
        var film = new Film
        {
            Title = dto.Title,
            Director = dto.Director,
            Genre = dto.Genre,
            Duration = dto.Duration,
            ReleaseDate = dto.ReleaseDate,
            Description = dto.Description,
            CoverUrl = dto.CoverUrl,
            TrailerUrl = dto.TrailerUrl,
            BannerUrl = dto.BannerUrl
        };

        await Repo.AddAsync(film);
        return MapToReadDTO(film);
    }

    public async Task<bool> UpdateAsync(int id, FilmUpdateDTO dto)
    {
        var film = await Repo.GetByIdAsync(id);
        if (film is null) return false;

        film.Title = dto.Title;
        film.Director = dto.Director;
        film.Genre = dto.Genre;
        film.Duration = dto.Duration;
        film.ReleaseDate = dto.ReleaseDate;
        film.Description = dto.Description;
        film.CoverUrl = dto.CoverUrl;
        film.TrailerUrl = dto.TrailerUrl;
        film.BannerUrl = dto.BannerUrl;

        await Repo.UpdateAsync(film);
        return true;
    }

    public new async Task<bool> DeleteAsync(int id)
    {
        var film = await Repo.GetByIdAsync(id);
        if (film is null) return false;

        await Repo.DeleteAsync(film.Id);
        return true;
    }

    private static FilmReadDTO MapToReadDTO(Film film)
        => new()
        {
            Id = film.Id,
            Title = film.Title,
            Director = film.Director,
            Genre = film.Genre,
            Duration = film.Duration,
            ReleaseDate = film.ReleaseDate,
            Description = film.Description,
            CoverUrl = film.CoverUrl,
            TrailerUrl = film.TrailerUrl,
            BannerUrl = film.BannerUrl,
            Screenings = film.Screenings == null
                ? []
                : film.Screenings
                    .Where(s => s != null && s.Screen != null)
                    .Select(s => new ScreeningReadDTO
                    {
                        Id = s.Id,
                        StartTime = s.StartTime,
                        EndTime = s.EndTime,
                        FilmId = film.Id,
                        FilmTitle = film.Title,
                        ScreenId = s.Screen.Id,
                        ScreenName = s.Screen.Name
                    })
        };
}
