using Dal.Football.Models;
using Dal.Player.Models;

namespace Dal.Player.Interfaces
{
    public interface IFootballRepository
    {
        Task<Guid> CreatePlayerAsync(PlayerDal player, TeamDal team, CountryDal country);
        Task<PlayerViewDal[]> GetPlayersAsync();
        Task<TeamDal[]> GetTeamsAsync();
        Task<TeamDal> GetTeamAsync(Guid teamId);
        Task<TeamDal> GetTeamByNameAsync(string teamName);
        Task<CountryDal> GetCountryAsync(Guid countryId);
        Task<CountryDal> GetCountryByNameAsync(string countryName);
        Task<Guid> EditPlayerAsync(PlayerDal player, TeamDal team, CountryDal country);
    }
}
