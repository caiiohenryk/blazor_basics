using blazor_studies.Models;
using blazor_studies.Models.Dto;

namespace blazor_studies.Data
{
    public interface IGameRepository
    {
        Task AddGame(Game game, CancellationToken ctoken);
        Task<GameResponseDto> FindById(Guid id, CancellationToken ctoken);
        Task<List<GameResponseDto>> FindAll(CancellationToken ctoken);
        Task UpdateInfos(Guid gameId, Game game, CancellationToken ctoken);
    }
}