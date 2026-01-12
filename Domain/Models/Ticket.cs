namespace TheaterBackend.Domain.Models;

public class Ticket
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public Screening Screening { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int SeatColumn { get; set; }
    public int SeatRow { get; set; }
}
