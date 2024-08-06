using blazor_studies.Models;
using blazor_studies.Models.Dto;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace blazor_studies.Data.Repositories
{
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
    }
}