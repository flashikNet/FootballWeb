using Application.Interfaces;
using Application.Models.Response;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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
