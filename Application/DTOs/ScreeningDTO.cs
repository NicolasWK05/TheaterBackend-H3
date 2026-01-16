
namespace TheaterBackend.Application.DTOs;

public class ScreeningReadDTO
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int FilmId { get; set; }
    public string FilmTitle { get; set; } = null!;
    public int ScreenId { get; set; }
    public string ScreenName { get; set; } = null!;
}

public class ScreeningCreateDTO
{
    public int FilmId { get; set; }
    public int ScreenId { get; set; }
    public DateTime StartTime { get; set; }
}
