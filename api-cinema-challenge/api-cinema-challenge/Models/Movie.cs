using System.Text.Json.Serialization;

namespace cinema.Models;

public class Movie : BaseData
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Rating { get; set; }
    public required string Description { get; set; }
    public required int RuntimeMins { get; set; }

    [JsonIgnore]
    public IEnumerable<Screening> Screenings { get; set; }
}
