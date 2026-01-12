namespace GameCollectionPlayApi.Dtos;

public class GameCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Cover { get; set; } = string.Empty;
    public int PersonalRating { get; set; }

    public int StatusId { get; set; }

    public List<int> PlatformIds { get; set; } = new();
    public List<int> GenderIds { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
