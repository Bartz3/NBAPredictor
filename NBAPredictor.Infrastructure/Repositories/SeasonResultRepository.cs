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
    public class SeasonResultRepository : ISeasonResultRepository
    {
        private readonly NBAPredictionDbContext _context;

        public SeasonResultRepository(NBAPredictionDbContext context)
        {
            _context = context;
        }

        public async Task<List<SeasonResult>> GetBySeasonIdAsync(int seasonId)
        {
            return await _context.SeasonResults
                .Where(r => r.SeasonId == seasonId)
                .Include(r => r.Team)
                .ToListAsync();
        }
    }
}
