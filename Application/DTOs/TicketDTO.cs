
namespace TheaterBackend.Application.DTOs;

public class TicketCreateDTO
{
    public int ScreeningId { get; set; }
    public int SeatRow { get; set; }
    public int SeatColumn { get; set; }
}

public class TicketReadDTO
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string FilmTitle { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public int SeatRow { get; set; }
    public int SeatColumn { get; set; }
}
