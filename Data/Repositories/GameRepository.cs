using blazor_studies.Models;
using blazor_studies.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace blazor_studies.Data.Repositories
{
    // This class serves as a "service" layer too. Im doing that way cuz idk how DotNet developers do it.
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task AddGame(Game game, CancellationToken ctoken) {
            var newGame = new Game(game.Name, game.GameCategory);
            if (string.IsNullOrWhiteSpace(newGame.Name)) {
                throw new ArgumentException("Name can't be null.");
            }
            Console.WriteLine($"Adding game: Name={newGame.Name}, Category={newGame.GameCategory}");
            await _context.Games.AddAsync(newGame, ctoken);
            await _context.SaveChangesAsync(ctoken);
        }

         public async Task<GameResponseDto> FindById(Guid id, CancellationToken ctoken) {
            var game = await _context.Games.FindAsync(id, ctoken);
            if (game == null) return null;
            return new GameResponseDto(game.Id, game.Name, game.GameCategory);
        }

        public async Task<List<GameResponseDto>> FindAll(CancellationToken ctoken) {
            var gameList = await _context.Games
                                        .Select(game => new GameResponseDto(game.Id, game.Name, game.GameCategory))
                                        .ToListAsync(ctoken);
            return gameList;
        }
        
        public async Task UpdateInfos(Guid gameId, Game game, CancellationToken ctoken) {
            var update = await _context.Games
                                        .SingleOrDefaultAsync(
                                            update => update.Id == gameId, ctoken);
            update.Update(game.Name, game.GameCategory);
            await _context.SaveChangesAsync(ctoken);
        }

    }
}