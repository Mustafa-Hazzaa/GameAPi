using GameStore.Api.DTOs;
using GameStore.Api.Models;

namespace GameStore.Api.Mappers;

public static class GameMapper
{
    public static GameDto FromEntity(Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            Genre = game.Genre,
            Platform = game.Platform,
            ReleaseYear = game.ReleaseYear,
            Rating = game.Rating,
            IsCompleted = game.IsCompleted
        };
    }

    public static Game ToEntity(CreateGameDto dto)
    {
        return new Game(
            dto.Title,
            dto.Description,
            dto.Genre,
            dto.Platform,
            dto.ReleaseYear,
            dto.Rating,
            dto.IsCompleted
        );
}

    public static void ApplyUpdate(Game game, UpdateGameDto dto)
    {
        game.Title = dto.Title;
        game.Description = dto.Description;
        game.Genre = dto.Genre;
        game.Platform = dto.Platform;
        game.ReleaseYear = dto.ReleaseYear;
        game.Rating = dto.Rating;
        game.IsCompleted = dto.IsCompleted;
    }
}