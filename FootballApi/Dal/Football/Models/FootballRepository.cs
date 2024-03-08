using Dal.Football.Models;
using Dal.Player.Contexts;
using Dal.Player.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Player.Models
{
    public class FootballRepository : IFootballRepository
    {
        public FootballRepository()
        {
            
        }
        public async Task<Guid> CreatePlayerAsync(PlayerDal player, TeamDal team, CountryDal country)
        {
            using (var db = new FootballContext())
            {
                await db.Players.AddAsync(player);
                if (team is not null)
                {
                    await db.Teams.AddAsync(team);
                }
                if (country is not null)
                {
                    await db.Countries.AddAsync(country);
                }
                await db.SaveChangesAsync();
                return player.Id;
            }
        }

        public async Task<Guid> EditPlayerAsync(PlayerDal editedPlayer, TeamDal team, CountryDal country)
        {
            using var db = new FootballContext();
            var oldPlayer = await db.Players.FindAsync(editedPlayer.Id);
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
                await db.Teams.AddAsync(team);
            }
            if (country is not null)
            {
                await db.Countries.AddAsync(country);
            }
            await db.SaveChangesAsync();
            return editedPlayer.Id;
        }

        public async Task<CountryDal> GetCountryAsync(Guid countryId)
        {
            using var db = new FootballContext();
            return await db.Countries.FindAsync(countryId);
        }

        public async Task<CountryDal> GetCountryByNameAsync(string countryName)
        {
            using var db = new FootballContext();
            return await db.Countries.Where(c => c.Name == countryName).FirstOrDefaultAsync();
        }

        public async Task<PlayerViewDal[]> GetPlayersAsync()
        {
            using var db = new FootballContext();
            return await db.PlayersView.ToArrayAsync();
        }

        public async Task<TeamDal> GetTeamAsync(Guid teamId)
        {
            using var db = new FootballContext();
            return await db.Teams.FindAsync(teamId);
        }

        public async Task<TeamDal> GetTeamByNameAsync(string teamName)
        {
            using var db = new FootballContext();
            return await db.Teams.Where(t => t.Name == teamName).FirstOrDefaultAsync();
        }

        public async Task<TeamDal[]> GetTeamsAsync()
        {
            using var db = new FootballContext();
            return await db.Teams.ToArrayAsync();
        }
    }
}
