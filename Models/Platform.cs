namespace GameCollectionPlayApi.Models;

public class Platform
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
