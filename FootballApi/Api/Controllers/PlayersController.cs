using Application.Models.Request;
using Application.Models.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PostApi.Controllers
{
    [ApiController]
    [Route("/api/players")]
    public class PlayersController : ControllerBase
    {

        private readonly IPlayerService _service;

        public PlayersController(IPlayerService service)
        {
            _service = service;
        }

        [Route("get")]
        [HttpGet]
        [ProducesResponseType<GetPlayerResponse[]>(200)]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var players = await _service.GetPlayersAsync();
            return Ok(players);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType<CreatePlayerResponse>(201)]
        public async Task<IActionResult> CreatePlayerAsync(CreatePlayerRequest req)
        {
            var res = await _service.CreatePlayerAsync(req);
            return new ObjectResult(res) { StatusCode = 201 };
        }

        [HttpPut]
        [Route("edit")]
        [ProducesResponseType<CreatePlayerResponse>(200)]
        public async Task<IActionResult> EditPlayerAsync(EditPlayerRequest req)
        {
            var res = await _service.EditPlayerAsync(req);
            return Ok(res);
        }
    }
}
