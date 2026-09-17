using System.ComponentModel.DataAnnotations;
using GameStore.Api.Enums;

public class Game
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Title { get; set; }

    public string Description { get; set; }

    public GameGenre Genre { get; set; }

    public Platform Platform { get; set; }

    public int ReleaseYear { get; set; }

    [Range(0, 5)]
    public int Rating { get; set; }

    public bool IsCompleted { get; set; }

}