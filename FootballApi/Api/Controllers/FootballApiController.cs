using Api.Football.Request;
using Api.Football.Response;
using Logic.Player.Interface;
using Logic.Player.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace PostApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class FootballApiController : ControllerBase
    {

        private readonly IFootballLogicManager _logicManager;

        public FootballApiController(IFootballLogicManager logicManager)
        {
            _logicManager = logicManager;
        }

        [Route("players")]
        [HttpGet]
        [ProducesResponseType<PlayerResponse[]>(200)]
        public async Task<IActionResult> GetPlayersAsync()
        {
            var players = await _logicManager.GetPlayersAsync();
            var playersResponse = players.Select(p => new PlayerResponse()
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Sex = p.Sex,
                BirthDate = p.BirthDate,
                Team = p.Team,
                Country = p.Country,
            })
            .ToArray();

            return Ok(playersResponse);
        }

        [HttpPost]
        [Route("player")]
        [ProducesResponseType<CreatePlayerResponse>(201)]
        public async Task<IActionResult> CreatePlayerAsync(CreatePlayerRequest dto)
        {
            var res = await _logicManager.CreatePlayerAsync(new CreatePlayerLogic
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Sex = dto.Sex,
                BirthDate = dto.BirthDate,
                Team = dto.Team,
                Country = dto.Country,
            });
            return new ObjectResult(new CreatePlayerResponse(){ Id = res}){ StatusCode = 201};
        }

        [HttpPut]
        [Route("player")]
        [ProducesResponseType<CreatePlayerResponse>(200)]
        public async Task<IActionResult> EditPlayerAsync(EditPlayerRequest dto)
        {
            var res = await _logicManager.EditPlayerAsync(new EditPlayerLogic
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Sex = dto.Sex,
                BirthDate = dto.BirthDate,
                Team = dto.Team,
                Country = dto.Country
            });
            return new ObjectResult(new EditPlayerResponse() { Id = res }) { StatusCode = 200 };
        }

        [HttpGet]
        [Route("teams")]
        [ProducesResponseType<TeamResponse[]>(200)]
        public async Task<IActionResult> GetTeamsAsync()
        {
            var teams = await _logicManager.GetTeamsAsync();    
            var teamsResponse = teams.Select(t => new TeamResponse()
            {
                Name = t.Name,
            }).ToArray();

            return Ok(teamsResponse);
        }
    }
}
