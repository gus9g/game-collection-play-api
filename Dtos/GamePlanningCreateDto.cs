namespace GameCollectionPlayApi.Dtos;

public class GamePlanningCreateDto
{
    public int GameId { get; set; }
    public int FellPlayRating { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int GameplayRating { get; set; }
    public int StatusGamePlanningId { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
