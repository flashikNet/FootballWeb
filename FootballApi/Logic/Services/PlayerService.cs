using Application.Interfaces;
using Application.Models.Request;
using Domain.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<CreatePlayerResponse> CreatePlayerAsync(CreatePlayerRequest player)
        {
            Team team;
            if (player.TeamId == 0)
            {
                team = new Team() { Name = player.TeamName };
            }
            else
            {
                team = await _unitOfWork.Teams.GetAsync(player.TeamId);
            }
            var playerEntity = new Player()
            {
                Name = player.Name,
                Surname = player.Surname,
                BirthDate = player.BirthDate,
                Sex = player.Sex,
                Team = team,
                Country = (Country)player.Country,
            };
            _unitOfWork.Players.Create(playerEntity);
            return new() { Id = playerEntity.Id };
        }

        public async Task<EditPlayerResponse> EditPlayerAsync(EditPlayerRequest player)
        {
            var playerEntity = new Player() 
            {
                Id = player.Id,
                Name = player.Name,
                Surname = player.Surname,
                BirthDate = player.BirthDate,
                Sex = player.Sex,
                Team = await _unitOfWork.Teams.GetAsync(player.TeamId),
                Country = (Country)player.Country,

            };

            await _unitOfWork.Players.UpdateAsync(playerEntity);
            _unitOfWork.Commit();
            return new() { Id = playerEntity.Id };
        }

        public Task<GetPlayerResponse[]> GetPlayersAsync()
        {
            return _unitOfWork.Players
                .GetAll().Include(p => p.Team)
                .Select(p => new GetPlayerResponse()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    BirthDate = p.BirthDate,
                    Sex = p.Sex,
                    TeamId = p.Team.Id,
                    TeamName = p.Team.Name,
                    Country = p.Country.ToString(),

                });
        }
    }
}
