using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Entities
{
    public class UserScore
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public int Points { get; set; }  // All points per season
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
