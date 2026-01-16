namespace TheaterBackend.Domain.Models;

public class Theater
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    // Navigation
    public ICollection<Screen> Screens { get; set; } = new List<Screen>();
}
