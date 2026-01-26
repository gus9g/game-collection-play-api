namespace GameCollectionPlayApi.Models;

public class GamePlanning
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int FellPlayRating { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int GameplayRating { get; set; }

    // 🔗 N:1 → Status
    public int StatusGamePlanningId { get; set; }
    public StatusGamePlanning StatusGamePlanning { get; set; } = null!;
}
