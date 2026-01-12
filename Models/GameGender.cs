namespace GameCollectionPlayApi.Models;

public class GameGender
{
    public int GameId { get; set; }
    public Game Game { get; set; } = null!;

    public int GenderId { get; set; }
    public Gender Gender { get; set; } = null!;
}
