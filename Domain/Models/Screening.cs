namespace TheaterBackend.Domain.Models;

public class Screening
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    // Foreign keys
    public int FilmId { get; set; }
    public int ScreenId { get; set; }

    // Navigation
    public Film Film { get; set; } = null!;
    public Screen Screen { get; set; } = null!;
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
