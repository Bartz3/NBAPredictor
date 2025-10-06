using MediatR;
using Microsoft.AspNetCore.Identity;
using NBAPredictor.Core.Interfaces;
using NBAPredictor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Core.Commands.Bets
{
    public class PlaceBetCommandHandler : IRequestHandler<PlaceBetCommand>
    {
        private readonly IUserRepository _users;
        private readonly ITeamRepository _teams;
        private readonly UserManager<User> _userManager;
        public PlaceBetCommandHandler(IUserRepository users, ITeamRepository teams)
        {
            _users = users;
            _teams = teams;
        }

        public async Task<Unit> Handle(PlaceBetCommand request, CancellationToken cancellationToken)
        {
            var user = await _users.GetByIdAsync(request.UserId);
            var team = await _teams.GetTeamById(request.TeamId);

            user.PlaceBet(team, request.Position);
            await _users.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
