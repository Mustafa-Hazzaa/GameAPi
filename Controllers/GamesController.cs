using GameStore.Api.DTOs;
using GameStore.Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace GameStore.Api.Controllers;



[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet(Name ="GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var games =await _gameService.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("{id:guid}",Name ="GetById")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        [HttpPost(Name ="Create")]
        public async Task<IActionResult> Create([FromBody] CreateGameDto dto)
        {
            var game = await _gameService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpPut("{id:guid}",Name ="Update")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateGameDto dto)
        {
            var updated  = await _gameService.UpdateAsync(id , dto);
            
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}",Name ="Delete")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deleted  = await _gameService.DeleteAsync(id);
            
            if (!deleted)
                return NotFound();
            return NoContent();
        }
}