using Projekt.DTOS.Opinion;

namespace Projekt.DTOS.Game;

public class GetGameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } 
    public Category Category { get; set; }
    public GetOpinionDto? Opinion { get; set; }
}