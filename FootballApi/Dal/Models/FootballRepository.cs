using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models
{
    public class FootballRepository : IFootballRepository
    {
        private FootballContext _db;
        public FootballRepository(FootballContext db)
        {
            _db = db;
        }
        public async Task<Guid> CreatePlayerAsync(Player player, Team team, Country country)
        {
            await _db.Players.AddAsync(player);
            if (team is not null)
            {
                await _db.Teams.AddAsync(team);
            }
            if (country is not null)
            {
                await _db.Countries.AddAsync(country);
            }
            await _db.SaveChangesAsync();
            return player.Id;
        }

        public async Task<Guid> EditPlayerAsync(Player editedPlayer, Team team, Country country)
        {
            var oldPlayer = await _db.Players.FindAsync(editedPlayer.Id);
            if (oldPlayer is not null)
            {
                oldPlayer.Name = editedPlayer.Name;
                oldPlayer.Surname = editedPlayer.Surname;
                oldPlayer.Sex = editedPlayer.Sex;
                oldPlayer.BirthDate = editedPlayer.BirthDate;
                oldPlayer.TeamId = editedPlayer.TeamId;
                oldPlayer.CountryId = editedPlayer.CountryId;
            }
            if (team is not null)
            {
                await _db.Teams.AddAsync(team);
            }
            if (country is not null)
            {
                await _db.Countries.AddAsync(country);
            }
            await _db.SaveChangesAsync();
            return editedPlayer.Id;
        }

        public async Task<Country> GetCountryAsync(Guid countryId)
        {
            return await _db.Countries.FindAsync(countryId);
        }

        public async Task<Country> GetCountryByNameAsync(string countryName)
        {
            return await _db.Countries.Where(c => c.Name == countryName).FirstOrDefaultAsync();
        }

        public async Task<Player[]> GetPlayersAsync()
        {
            return await _db.PlayersView.ToArrayAsync();
        }

        public async Task<Team> GetTeamAsync(Guid teamId)
        {
            return await _db.Teams.FindAsync(teamId);
        }

        public async Task<Team> GetTeamByNameAsync(string teamName)
        {
            return await _db.Teams.Where(t => t.Name == teamName).FirstOrDefaultAsync();
        }

        public async Task<Team[]> GetTeamsAsync()
        {
            return await _db.Teams.ToArrayAsync();
        }
    }
}
