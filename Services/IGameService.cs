using GameStore.Api.DTOs;

namespace GameStore.Api.Services;
public interface IGameService
{
    Task<List<GameDto>> GetAllAsync();

    Task<GameDto?> GetByIdAsync(Guid id);

    Task<GameDto> CreateAsync(CreateGameDto dto);

    Task<bool> UpdateAsync(Guid id, UpdateGameDto dto);

    Task<bool> DeleteAsync(Guid id);
}