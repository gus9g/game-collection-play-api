namespace GameCollectionPlayApi.Models;

public class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // Código usado pelo front para buscar imagem local
    public string Cover { get; set; } = string.Empty;

    // ⭐ Rating com regra automática
    private int _personalRating = 1;
    public int PersonalRating
    {
        get => _personalRating;
        set => _personalRating = value < 1 || value > 10 ? 1 : value;
    }

    // 🔗 N:1 → Status
    public int StatusId { get; set; }
    public Status Status { get; set; } = null!;

    // 🔗 N:N → Platforms
    public ICollection<GamePlatform> GamePlatforms { get; set; } = new List<GamePlatform>();

    // 🔗 N:N → Genders
    public ICollection<GameGender> GameGenders { get; set; } = new List<GameGender>();

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
