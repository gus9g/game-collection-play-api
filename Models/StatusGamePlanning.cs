namespace GameCollectionPlayApi.Models;

public class StatusGamePlanning
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public ICollection<GamePlanning> GamePlanning { get; set; } = new List<GamePlanning>();

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
