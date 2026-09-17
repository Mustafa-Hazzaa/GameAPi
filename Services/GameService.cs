using GameStore.Api.DTOs;
using GameStore.Api.Enums;
using GameStore.Api.Exceptions;
using GameStore.Api.Mappers;
using GameStore.Api.Models;

namespace GameStore.Api.Services;

public class GameService : IGameService
{
    private readonly List<Game> _games = new()
{
    new Game(
        "The Witcher 3",
        "An open-world RPG.",
        GameGenre.RPG,
        Platform.PC,
        2015,
        5,
        true
    ),

    new Game(
        "Minecraft",
        "A sandbox game about building and exploration.",
        GameGenre.Adventure,
        Platform.PC,
        2011,
        5,
        false
    ),

    new Game(
        "Assassin's Creed IV: Black Flag",
        "An open-world pirate adventure.",
        GameGenre.Action,
        Platform.PC,
        2013,
        5,
        true
    )
};

    public Task<List<GameDto>> GetAllAsync()
    {
        var games = _games
            .Select(GameMapper.FromEntity)
            .ToList();

        return Task.FromResult(games);
    }

    public Task<GameDto> GetByIdAsync(Guid id)
    {
        var game = _games.FirstOrDefault(game => game.Id == id);

        if (game == null)
            throw new GameNotFoundException(id);

        var dto = GameMapper.FromEntity(game);

        return Task.FromResult<GameDto>(dto);
    }

    public Task<GameDto> CreateAsync(CreateGameDto dto)
    {
        var game = GameMapper.ToEntity(dto);

        _games.Add(game);

        var dtoResult = GameMapper.FromEntity(game);

        return Task.FromResult(dtoResult);
    }

    public Task<bool> UpdateAsync(Guid id, UpdateGameDto dto)
    {
        var game = _games.FirstOrDefault(game => game.Id == id);

        if (game == null)
            throw new GameNotFoundException(id);
        GameMapper.ApplyUpdate(game,dto);

        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var game = _games.FirstOrDefault(game => game.Id == id);

        if (game == null)
            throw new GameNotFoundException(id);

        _games.Remove(game);

        return Task.FromResult(true);
    }
}