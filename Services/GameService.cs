using GameStore.Api.DTOs;
using GameStore.Api.Mappers;
using GameStore.Api.Models;

namespace GameStore.Api.Services;

public class GameService : IGameService
{
    private readonly List<Game> _games = new();

    public Task<List<GameDto>> GetAllAsync()
    {
        var games = _games
            .Select(GameMapper.FromEntity)
            .ToList();

        return Task.FromResult(games);
    }

    public Task<GameDto?> GetByIdAsync(Guid id)
    {
        var game = _games.FirstOrDefault(game => game.Id == id);

        if (game == null)
            return Task.FromResult<GameDto?>(null);

        var dto = GameMapper.FromEntity(game);

        return Task.FromResult<GameDto?>(dto);
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
            return Task.FromResult(false);

        GameMapper.ApplyUpdate(game,dto);

        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var game = _games.FirstOrDefault(game => game.Id == id);

        if (game == null)
            return Task.FromResult(false);

        _games.Remove(game);

        return Task.FromResult(true);
    }
}