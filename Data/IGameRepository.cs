using blazor_studies.Models;

namespace blazor_studies.Data
{
    public interface IGameRepository
    {
        Task AddGame(Game game, CancellationToken ctoken);
    }
}