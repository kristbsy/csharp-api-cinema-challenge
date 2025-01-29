namespace cinema.Dto;

public class ScreeningPost
{
    public required int ScreenNumber { get; set; }
    public required int Capacity { get; set; }
    public required DateTime StartsAt { get; set; }
}
