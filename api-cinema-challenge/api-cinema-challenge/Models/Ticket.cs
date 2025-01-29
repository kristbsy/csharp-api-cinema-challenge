using System.Text.Json.Serialization;

namespace cinema.Models;

public class Ticket : BaseData
{
    public int Id { get; set; }
    public required int NumSeats { get; set; }

    [JsonIgnore]
    public int CustomerId { get; set; }

    [JsonIgnore]
    public virtual Customer? Customer { get; set; }

    [JsonIgnore]
    public int ScreeningId { get; set; }

    [JsonIgnore]
    public virtual Screening? Screening { get; set; }
}
