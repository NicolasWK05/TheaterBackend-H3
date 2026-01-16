namespace TheaterBackend.Domain.Models;

public class Ticket
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    // Foreign keys
    public int ScreeningId { get; set; }
    public int PersonId { get; set; }

    // Navigation
    public Screening Screening { get; set; } = null!;
    public Person Person { get; set; } = null!;

    public int SeatRow { get; set; }
    public int SeatColumn { get; set; }
}
