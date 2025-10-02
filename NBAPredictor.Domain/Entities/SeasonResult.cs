using NBAPredictor.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Entities
{
    public class SeasonResult
    {
        public int Id { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public Conference Conference { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int ActualRank { get; set; } // np. 1..15
    }
}
