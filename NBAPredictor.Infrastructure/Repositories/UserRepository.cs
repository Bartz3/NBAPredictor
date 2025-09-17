using Microsoft.EntityFrameworkCore;
using NBAPredictor.Core.Interfaces;
using NBAPredictor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NBAPredictionDbContext _nbaPredictionDbContext;

        public UserRepository(NBAPredictionDbContext nbaPredictionDbContext)
        {
            _nbaPredictionDbContext = nbaPredictionDbContext;
        }

        public async Task<User?> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var user = await _nbaPredictionDbContext.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return user;
        }
    }
}
