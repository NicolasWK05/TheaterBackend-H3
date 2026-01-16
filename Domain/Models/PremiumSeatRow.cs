namespace TheaterBackend.Domain.Models;

public class PremiumSeatRow
{
    public int Id { get; set; }
    public int RowNumber { get; set; }

    // FK
    public int ScreenId { get; set; }

    // Navigation
    public Screen Screen { get; set; } = null!;
}
