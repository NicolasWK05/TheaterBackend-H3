namespace TheaterBackend.Domain.Models;

public class Screening
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Film Film { get; set; }
    public Screen Screen { get; set; }
}
