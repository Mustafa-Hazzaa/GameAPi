using GameStore.Api.Enums;
using GameStore.Api.Models;

namespace GameStore.Api.DTOs;

public class GameDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public GameGenre Genre { get; set; }
    public Platform Platform { get; set; }
    public int ReleaseYear { get; set; }
    public int Rating { get; set; }
    public bool IsCompleted { get; set; }
}