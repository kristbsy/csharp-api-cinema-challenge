using System.Text.Json.Serialization;

namespace cinema.Models;

public class Customer : BaseData
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }

    [JsonIgnore]
    public IEnumerable<Ticket> Tickets { get; set; }
}
