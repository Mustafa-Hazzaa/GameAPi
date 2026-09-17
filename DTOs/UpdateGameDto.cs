using System.ComponentModel.DataAnnotations;
using GameStore.Api.Enums;

namespace GameStore.Api.DTOs;

public class UpdateGameDto
{
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public GameGenre Genre { get; set; }

    [Required]
    public Platform Platform { get; set; }

    [Range(1900, 2100)]
    public int ReleaseYear { get; set; }

    [Range(0, 5)]
    public int Rating { get; set; }

    public bool IsCompleted { get; set; }
}