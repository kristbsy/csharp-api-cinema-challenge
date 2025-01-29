using cinema.Models;

namespace cinema.Dto;

public class MoviePartial
{
    public string? Title { get; set; }
    public string? Rating { get; set; }
    public string? Description { get; set; }
    public int? RuntimeMins { get; set; }
}

public class MoviePostDto
{
    public required string Title { get; set; }
    public required string Rating { get; set; }
    public required string Description { get; set; }
    public required int RuntimeMins { get; set; }
    public required IEnumerable<ScreeningPost> Screenings { get; set; }
}
