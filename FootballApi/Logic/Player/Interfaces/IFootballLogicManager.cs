using Dal.Football.Models;
using Dal.Player.Models;
using Logic.Player.Models;

namespace Logic.Player.Interface
{
    public interface IFootballLogicManager
    {
        Task<Guid> CreatePlayerAsync(CreatePlayerLogic player);
        Task<PlayerViewDal[]> GetPlayersAsync();
        Task<TeamDal[]> GetTeamsAsync();
        Task<Guid> EditPlayerAsync(EditPlayerLogic player);
    }
}
