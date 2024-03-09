using Dal.Football.Models;
using Dal.Player.Contexts;
using Dal.Player.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Player.Models
{
    public class FootballRepository : IFootballRepository
    {
        private FootballContext _db;
        public FootballRepository(FootballContext db)
        {
            _db = db;
        }
        public async Task<Guid> CreatePlayerAsync(PlayerDal player, TeamDal team, CountryDal country)
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

        public async Task<Guid> EditPlayerAsync(PlayerDal editedPlayer, TeamDal team, CountryDal country)
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

        public async Task<CountryDal> GetCountryAsync(Guid countryId)
        {
            return await _db.Countries.FindAsync(countryId);
        }

        public async Task<CountryDal> GetCountryByNameAsync(string countryName)
        {
            return await _db.Countries.Where(c => c.Name == countryName).FirstOrDefaultAsync();
        }

        public async Task<PlayerViewDal[]> GetPlayersAsync()
        {
            return await _db.PlayersView.ToArrayAsync();
        }

        public async Task<TeamDal> GetTeamAsync(Guid teamId)
        {
            return await _db.Teams.FindAsync(teamId);
        }

        public async Task<TeamDal> GetTeamByNameAsync(string teamName)
        {
            return await _db.Teams.Where(t => t.Name == teamName).FirstOrDefaultAsync();
        }

        public async Task<TeamDal[]> GetTeamsAsync()
        {
            return await _db.Teams.ToArrayAsync();
        }
    }
}
