using System.Text.Json.Serialization;

namespace cinema.Models;

public class Screening : BaseData
{
    public int Id { get; set; }
    public int ScreenNumber { get; set; }
    public required int Capacity { get; set; }
    public required DateTime StartsAt { get; set; }

    [JsonIgnore]
    public int MovieId { get; set; }

    [JsonIgnore]
    public virtual Movie? Movie { get; set; }

    [JsonIgnore]
    public virtual IEnumerable<Ticket>? Tickets { get; set; }
}
