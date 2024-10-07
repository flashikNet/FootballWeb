using Application.Interfaces;
using Application.Models.Request;
using Domain.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Application.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    internal class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreatePlayerResponse> CreatePlayerAsync(CreatePlayerRequest request)
        {
            var team = (await _unitOfWork.Teams
               .GetAll()
               .FirstOrDefaultAsync(t => t.Name == request.TeamName))
               ?? new Team() { Name = request.TeamName };
            var playerEntity = new Player()
            {
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                Sex = Enum.Parse<Sex>(request.Sex),
                Team = team,
                Country = Enum.Parse<Country>(request.Country),
            };
            await _unitOfWork.Players.CreateAsync(playerEntity);
            await _unitOfWork.CommitAsync();
            return new() { Id = playerEntity.Id };
        }

        public async Task<EditPlayerResponse> EditPlayerAsync(EditPlayerRequest request)
        {
            var team = (await _unitOfWork.Teams
            .GetAll()
            .FirstOrDefaultAsync(t => t.Name == request.TeamName))
            ?? new Team() { Name = request.TeamName };
            var playerEntity = new Player()
            {
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                Sex = Enum.Parse<Sex>(request.Sex),
                Team = team,
                Country = Enum.Parse<Country>(request.Country),

            };

            await _unitOfWork.Players.UpdateAsync(playerEntity);
            await _unitOfWork.CommitAsync();
            return new() { Id = playerEntity.Id };
        }

        public async Task<GetPlayerResponse[]> GetPlayersAsync()
        {
            return await _unitOfWork.Players
                .GetAll().Include(p => p.Team)
                .Select(p => new GetPlayerResponse()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    BirthDate = p.BirthDate,
                    Sex = p.Sex.ToString(),
                    TeamName = p.Team.Name,
                    Country = p.Country.ToString(),

                }).ToArrayAsync();
        }
    }
}
