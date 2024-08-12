using Application.Models.Response;
using Domain.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeamService
    {
        Task<GetTeamResponse[]> GetTeamsAsync();
    }
}
