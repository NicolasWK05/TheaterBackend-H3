namespace TheaterBackend.Domain.Models;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public string CoverUrl { get; set; }
    public string? TrailerUrl { get; set; }
    public string? BannerUrl { get; set; }
}
