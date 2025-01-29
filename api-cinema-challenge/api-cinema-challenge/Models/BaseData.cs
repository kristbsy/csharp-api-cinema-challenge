namespace cinema.Models;

public class BaseData
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public BaseData()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Updated()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
