using System.Text.Json.Serialization;

namespace Projekt.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Category
{
    //game category
    FPS = 1,
    RPG = 2,
    MOBA = 3,
    RTS = 4,
    
}