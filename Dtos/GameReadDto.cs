namespace GameCollectionPlayApi.Dtos;

public class GameReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cover { get; set; }
    public int PersonalRating { get; set; }
    public StatusDto Status { get; set; }
    public List<PlatformDto> Platforms { get; set; }
    public List<GenderDto> Genders { get; set; }
}