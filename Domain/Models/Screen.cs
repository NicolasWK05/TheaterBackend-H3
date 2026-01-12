namespace TheaterBackend.Domain.Models;

public class Screen
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }
    public int PremiumSeatCount { get; set; }
    public List<int> PremiumSeatRows { get; set; }
    public Theater Theater { get; set; }
}
