namespace TheaterBackend.Application.DTOs;

public class TheaterCreateDTO
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
}

public class TheaterReadDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    public IEnumerable<ScreenSummaryDTO> Screens { get; set; }
}

public class TheaterUpdateDTO
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
}
