using Application.Interfaces;
using Application.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _service;
        public TeamsController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("teams")]
        [ProducesResponseType<GetTeamResponse[]>(200)]
        public async Task<IActionResult> GetTeamsAsync()
        {
            var teamsResponse = await _service.GetTeamsAsync();

            return Ok(teamsResponse);
        }
    }
}
