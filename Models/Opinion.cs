﻿using System.ComponentModel.DataAnnotations;

namespace Projekt.Models;

public class Opinion
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    [Range(1, 10, ErrorMessage = "1-10")]
    public int Rating { get; set; }
    public Game? Game { get; set; }
    public int GameId { get; set; }
}