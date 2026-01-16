namespace TheaterBackend.Domain.Models;

public class Film
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int Duration { get; set; } // minutes
    public DateTime ReleaseDate { get; set; }

    public string Description { get; set; } = null!;
    public string CoverUrl { get; set; } = null!;
    public string? TrailerUrl { get; set; }
    public string? BannerUrl { get; set; }

    // Navigation
    public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}
