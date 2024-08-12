using Application.Models.Request;
using Application.Models.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

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

        [Route("players")]
        [HttpGet]
        [ProducesResponseType<GetPlayerResponse[]>(200)]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var players = await _service.GetPlayersAsync();
            return Ok(players);
        }

        [HttpPost]
        [Route("player")]
        [ProducesResponseType<CreatePlayerResponse>(201)]
        public async Task<IActionResult> CreatePlayerAsync(CreatePlayerRequest dto)
        {
            var res = await _service.CreatePlayerAsync(dto);
            return new ObjectResult(new CreatePlayerResponse(){ Id = res}){ StatusCode = 201};
        }

        [HttpPut]
        [Route("player")]
        [ProducesResponseType<CreatePlayerResponse>(200)]
        public async Task<IActionResult> EditPlayerAsync(EditPlayerRequest dto)
        {
            var res = await _service.EditPlayerAsync(dto);
            return new ObjectResult(new EditPlayerResponse() { Id = res }) { StatusCode = 200 };
        }
    }
}
