using NBAPredictor.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Abbreviation { get; set; }
        public Conference Conference { get; set; }

        public ICollection<SeasonResult> Results { get; set; } = new List<SeasonResult>();
        public ICollection<UserBet> Bets { get; set; } = new List<UserBet>();
    }
}


// zrób oddzielną klasę fillera tak aby można bylo tylko wykorzystać ją w OnModelCreating