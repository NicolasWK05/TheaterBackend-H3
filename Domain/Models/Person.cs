namespace TheaterBackend.Domain.Models;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    // Navigation
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
