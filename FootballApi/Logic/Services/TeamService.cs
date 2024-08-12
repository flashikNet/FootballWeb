using Application.Interfaces;
using Application.Models.Response;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetTeamResponse[]> GetTeamsAsync()
        {
            var repository = _unitOfWork.Teams;
            return await repository
                .GetAll()
                .Select(t => new GetTeamResponse()
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToArrayAsync();
        }
    }
}
