namespace GameCollectionPlayApi.Dtos;

public class GamePlanningReadDto
{
    public int GameId { get; set; }
    public int FellPlayRating { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int GameplayRating { get; set; }
    public StatusGamePlanningDto StatusGamePlanning { get; set; }

}