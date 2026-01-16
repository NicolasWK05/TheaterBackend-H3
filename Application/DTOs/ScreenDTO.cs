namespace TheaterBackend.Application.DTOs;

public class ScreenCreateDTO
{
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    public int TheaterId { get; set; }
}

public class ScreenReadDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
    public int TheaterId { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    public int PremiumSeatCount { get; set; }
}

public class ScreenSummaryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
}

public class ScreenUpdateDTO
{
    public string Name { get; set; } = null!;
    public int Capacity { get; set; }
}
