namespace TheaterBackend.Domain.Models;

// This is just for determining which film is highlighted on the homepage :3
public class Showcase
{
    public int Id { get; set; }

    // FK
    public int FilmId { get; set; }

    // Navigation
    public Film Film { get; set; } = null!;
}
