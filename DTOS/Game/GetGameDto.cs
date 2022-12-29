using Projekt.DTOS.Opinion;

namespace Projekt.DTOS.Game;

public class GetGameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "CS:GO";
    public DateTime ReleaseDate { get; set; } = new DateTime(2012, 8, 21);
    public Category Category { get; set; } = Category.FPS;
    public GetOpinionDto? Opinion { get; set; }
}