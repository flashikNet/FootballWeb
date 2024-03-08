using Dal.Football.Models;
using Dal.Player.Interfaces;
using Dal.Player.Models;
using Logic.Player.Interface;

namespace Logic.Player.Models
{
    public class FootballLogicManager : IFootballLogicManager
    {
        private readonly IFootballRepository _repository;

        public FootballLogicManager(IFootballRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreatePlayerAsync(CreatePlayerLogic player)
        {
            var country = await _repository.GetCountryByNameAsync(player.Country);
            var team = await _repository.GetTeamByNameAsync(player.Team);
            var playerDal = new PlayerDal()
            {
                Id = Guid.NewGuid(),
                Name = player.Name,
                Surname = player.Surname,
                Sex = player.Sex,
                BirthDate = player.BirthDate,

            };
            bool IsCountryFound = true;
            bool isTeamFound = true;
            if (country is null)
            {
                country = new CountryDal() { Id = Guid.NewGuid(), Name = player.Country };
                IsCountryFound = false;
            }
            if (team is null)
            {
                team = new TeamDal() {Id = Guid.NewGuid(), Name = player.Team };
                isTeamFound = false;
            }
            playerDal.CountryId = country.Id;
            playerDal.TeamId = team.Id;
            return await _repository.CreatePlayerAsync(playerDal,
                isTeamFound ? null : team,
                IsCountryFound ? null : country
                );
        }

        public async Task<Guid> EditPlayerAsync(EditPlayerLogic player)
        {
            var country = await _repository.GetCountryByNameAsync(player.Country);
            var team = await _repository.GetTeamByNameAsync(player.Team);
            var playerDal = new PlayerDal()
            {
                Id = player.Id,
                Name = player.Name,
                Surname = player.Surname,
                Sex = player.Sex,
                BirthDate = player.BirthDate,

            };
            bool IsCountryFound = true;
            bool isTeamFound = true;
            if (country is null)
            {
                country = new CountryDal() { Id = Guid.NewGuid(), Name = player.Country };
                IsCountryFound = false;
            }
            if (team is null)
            {
                team = new TeamDal() { Id = Guid.NewGuid(), Name = player.Team };
                isTeamFound = false;
            }
            playerDal.CountryId = country.Id;
            playerDal.TeamId = team.Id;
            return await _repository.EditPlayerAsync(playerDal,
                isTeamFound ? null : team,
                IsCountryFound ? null : country
                );
        }

        public async Task<PlayerViewDal[]> GetPlayersAsync()
        {
            return await _repository.GetPlayersAsync();
        }

        public async Task<TeamDal[]> GetTeamsAsync()
        {
            return await _repository.GetTeamsAsync();
        }
    }
}
