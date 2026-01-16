namespace TheaterBackend.Application.DTOs;

public class FilmCreateDTO
{
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; } = null!;
    public string CoverUrl { get; set; } = null!;
    public string? TrailerUrl { get; set; }
    public string? BannerUrl { get; set; }
}

public class FilmReadDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int Duration { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; } = null!;
    public string CoverUrl { get; set; } = null!;
    public string? TrailerUrl { get; set; }
    public string? BannerUrl { get; set; }
    public IEnumerable<ScreeningReadDTO> Screenings { get; set; } = new List<ScreeningReadDTO>();
}

public class FilmUpdateDTO : FilmCreateDTO
{

}
