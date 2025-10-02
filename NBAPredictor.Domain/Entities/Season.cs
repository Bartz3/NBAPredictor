using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public bool IsActive { get; set; }

        public ICollection<SeasonResult> Results { get; set; } = new List<SeasonResult>();
        public ICollection<UserBet> Bets { get; set; } = new List<UserBet>();
        public ICollection<UserScore> Scores { get; set; } = new List<UserScore>();
    }
}
