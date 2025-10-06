using NBAPredictor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Core.Queries.Teams
{

    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, List<TeamDto>>
    {
        private readonly ITeamRepository _teams;

        public GetAllTeamsQueryHandler(ITeamRepository teams)
        {
            _teams = teams;
        }

        public async Task<List<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teams.GetAllAsync();
            return teams.Select(t => new TeamDto(t.Id, t.Name, t.City, t.Abbreviation)).ToList();
        }
    }

}
