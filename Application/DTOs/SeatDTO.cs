namespace TheaterBackend.Application.DTOs;

public class SeatReadDTO
{
    public int Id { get; set; }
    public int RowNumber { get; set; }
    public int ColumnNumber { get; set; }
    public bool IsPremium { get; set; }
    public bool IsAvailable { get; set; }
}

public class SeatCreateDTO
{
    public int RowNumber { get; set; }
    public int ColumnNumber { get; set; }
    public bool IsPremium { get; set; }
}
