using Application.Models.Response;

namespace Application.Interfaces
{
    public interface ITeamService
    {
        Task<GetTeamResponse[]> GetTeamsAsync();
    }
}
