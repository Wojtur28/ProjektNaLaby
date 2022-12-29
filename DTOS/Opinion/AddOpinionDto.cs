namespace Projekt.DTOS.Opinion;

public class AddOpinionDto
{
    public string Text { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int GameId { get; set; }
}