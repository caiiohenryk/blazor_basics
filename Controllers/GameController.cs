using blazor_studies.Data;
using blazor_studies.Models;
using blazor_studies.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace blazor_studies.Controllers
{
    [ApiController]
    [Route("/api/game")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;
        public GameController(IGameRepository repository) {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game game, CancellationToken ctoken) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _repository.AddGame(game, ctoken);

            var gameDto = new GameResponseDto {
                Name = game.Name,
                GameCategory = game.GameCategory     
            };
            return Ok(gameDto);
        }

    }
}