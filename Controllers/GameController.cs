using blazor_studies.Data;
using blazor_studies.Models;
using blazor_studies.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace blazor_studies.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
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
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponseDto>> FindGame([FromRoute] Guid id, CancellationToken ctoken) {
            var responseData = await _repository.FindById(id, ctoken);
            return Ok(responseData);
        }

        [HttpGet]
        public async Task<ActionResult<List<GameResponseDto>>> GetAll(CancellationToken ctoken) {
            var responseData = await _repository.FindAll(ctoken);
            return Ok(responseData);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateObject([FromRoute] Guid id, [FromBody] Game game, CancellationToken ctoken) {
            await _repository.UpdateInfos(id, game, ctoken);
            return NoContent();
        }
    }
}