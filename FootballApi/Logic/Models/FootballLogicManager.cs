using Application.Interfaces;
using Application.Models.Request;
using Domain.Entities;

namespace Application.Models
{
    public class FootballLogicManager : IPlayerService
    {
        private readonly IFootballRepository _repository;

        public FootballLogicManager(IFootballRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreatePlayerAsync(CreatePlayerRequest player)
        {
            var country = await _repository.GetCountryByNameAsync(player.Country);
            var team = await _repository.GetTeamByNameAsync(player.TeamName);
            var playerDal = new Player()
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
                country = new Country() { Id = Guid.NewGuid(), Name = player.Country };
                IsCountryFound = false;
            }
            if (team is null)
            {
                team = new Team() { Id = Guid.NewGuid(), Name = player.TeamName };
                isTeamFound = false;
            }
            playerDal.CountryId = country.Id;
            playerDal.TeamId = team.Id;
            return await _repository.CreatePlayerAsync(playerDal,
                isTeamFound ? null : team,
                IsCountryFound ? null : country
                );
        }

        public async Task<Guid> EditPlayerAsync(EditPlayerRequest player)
        {
            var country = await _repository.GetCountryByNameAsync(player.Country);
            var team = await _repository.GetTeamByNameAsync(player.Team);
            var playerDal = new Player()
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
                country = new Country() { Id = Guid.NewGuid(), Name = player.Country };
                IsCountryFound = false;
            }
            if (team is null)
            {
                team = new Team() { Id = Guid.NewGuid(), Name = player.Team };
                isTeamFound = false;
            }
            playerDal.CountryId = country.Id;
            playerDal.TeamId = team.Id;
            return await _repository.EditPlayerAsync(playerDal,
                isTeamFound ? null : team,
                IsCountryFound ? null : country
                );
        }

        public async Task<Player[]> GetPlayersAsync()
        {
            return await _repository.GetPlayersAsync();
        }

        public async Task<Team[]> GetTeamsAsync()
        {
            return await _repository.GetTeamsAsync();
        }
    }
}
