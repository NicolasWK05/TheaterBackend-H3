namespace TheaterBackend.Application.DTOs;

public class ShowcaseDTO
{
    public int FilmId { get; set; }
    public string Title { get; set; } = null!;
    public string BannerUrl { get; set; } = null!;
}
