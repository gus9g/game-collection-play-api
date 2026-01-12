namespace GameCollectionPlayApi.Models;

public class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public ICollection<GameGender> GameGenders { get; set; } = new List<GameGender>();

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
