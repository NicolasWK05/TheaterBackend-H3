namespace TheaterBackend.Domain.Models;

public class Seat
{
    public int Id { get; set; }
    public int RowNumber { get; set; }
    public int ColumnNumber { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsPremium { get; set; } = false;
}
