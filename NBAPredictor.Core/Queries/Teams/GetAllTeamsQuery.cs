using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Core.Queries.Teams;

public record GetAllTeamsQuery() : IRequest<List<TeamDto>>;
