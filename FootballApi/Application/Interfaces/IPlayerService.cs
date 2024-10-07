using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface IPlayerService
    {
        Task<CreatePlayerResponse> CreatePlayerAsync(CreatePlayerRequest player);
        Task<GetPlayerResponse[]> GetPlayersAsync();
        Task<EditPlayerResponse> EditPlayerAsync(EditPlayerRequest player);
    }
}
