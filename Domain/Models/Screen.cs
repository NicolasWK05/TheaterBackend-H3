namespace TheaterBackend.Domain.Models;

public class Screen
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    public int PremiumSeatCount { get; set; }

    // Foreign key
    public int TheaterId { get; set; }

    // Navigation
    public Theater Theater { get; set; } = null!;
    public ICollection<PremiumSeatRow> PremiumSeatRows { get; set; } = new List<PremiumSeatRow>();
    public ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
