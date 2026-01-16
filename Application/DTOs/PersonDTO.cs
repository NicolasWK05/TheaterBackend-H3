namespace TheaterBackend.Application.DTOs;

public class PersonDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
}

public class PersonChangePasswordDTO
{
    public int Id { get; set; }
    public string NewPassword { get; set; }
}

public class PersonCreateDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}

public class PersonUpdateDTO
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
