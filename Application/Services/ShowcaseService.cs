using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
using TheaterBackend.Domain.Models;
using TheaterBackend.Infrastructure.Repositories;
using TheaterBackend.Application.DTOs;

namespace TheaterBackend.Application.Services;

public class ShowcaseService(IShowcaseRepo repo) : GenericService<Showcase>(repo), IShowcaseService
{

    public async Task<ShowcaseDTO?> GetAsync()
    {
        var showcase = (await repo.GetAllAsync()).FirstOrDefault();
        if (showcase is null) return null;

        return new ShowcaseDTO
        {
            FilmId = showcase.Film.Id,
            Title = showcase.Film.Title,
            BannerUrl = showcase.Film.BannerUrl!
        };
    }
}
