using NBAPredictor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Core.Interfaces
{
    public interface IUserRepository
    {
         Task<User?> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
