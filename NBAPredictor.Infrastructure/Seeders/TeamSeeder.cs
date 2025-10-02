using NBAPredictor.Domain.Entities;
using NBAPredictor.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Infrastructure.Seeders
{
    public static class TeamSeeder
    {
        public static IEnumerable<Team> GetTeams()
        {
            return new List<Team>
            {
                // EASTERN CONFERENCE
                new Team { Id = 1, Name = "Boston Celtics", City = "Boston", Abbreviation = "BOS", Conference = Conference.East },
                new Team { Id = 2, Name = "Brooklyn Nets", City = "New York", Abbreviation = "BKN", Conference = Conference.East },
                new Team { Id = 3, Name = "New York Knicks", City = "New York", Abbreviation = "NYK", Conference = Conference.East },
                new Team { Id = 4, Name = "Philadelphia 76ers", City = "Philadelphia", Abbreviation = "PHI", Conference = Conference.East },
                new Team { Id = 5, Name = "Toronto Raptors", City = "Toronto", Abbreviation = "TOR", Conference = Conference.East },
                new Team { Id = 6, Name = "Chicago Bulls", City = "Chicago", Abbreviation = "CHI", Conference = Conference.East },
                new Team { Id = 7, Name = "Cleveland Cavaliers", City = "Cleveland", Abbreviation = "CLE", Conference = Conference.East },
                new Team { Id = 8, Name = "Detroit Pistons", City = "Detroit", Abbreviation = "DET", Conference = Conference.East },
                new Team { Id = 9, Name = "Indiana Pacers", City = "Indianapolis", Abbreviation = "IND", Conference = Conference.East },
                new Team { Id = 10, Name = "Milwaukee Bucks", City = "Milwaukee", Abbreviation = "MIL", Conference = Conference.East },
                new Team { Id = 11, Name = "Atlanta Hawks", City = "Atlanta", Abbreviation = "ATL", Conference = Conference.East },
                new Team { Id = 12, Name = "Charlotte Hornets", City = "Charlotte", Abbreviation = "CHA", Conference = Conference.East },
                new Team { Id = 13, Name = "Miami Heat", City = "Miami", Abbreviation = "MIA", Conference = Conference.East },
                new Team { Id = 14, Name = "Orlando Magic", City = "Orlando", Abbreviation = "ORL", Conference = Conference.East },
                new Team { Id = 15, Name = "Washington Wizards", City = "Washington", Abbreviation = "WAS", Conference = Conference.East },

                // WESTERN CONFERENCE
                new Team { Id = 16, Name = "Denver Nuggets", City = "Denver", Abbreviation = "DEN", Conference = Conference.West },
                new Team { Id = 17, Name = "Minnesota Timberwolves", City = "Minneapolis", Abbreviation = "MIN", Conference = Conference.West },
                new Team { Id = 18, Name = "Oklahoma City Thunder", City = "Oklahoma City", Abbreviation = "OKC", Conference = Conference.West },
                new Team { Id = 19, Name = "Portland Trail Blazers", City = "Portland", Abbreviation = "POR", Conference = Conference.West },
                new Team { Id = 20, Name = "Utah Jazz", City = "Salt Lake City", Abbreviation = "UTA", Conference = Conference.West },
                new Team { Id = 21, Name = "Golden State Warriors", City = "San Francisco", Abbreviation = "GSW", Conference = Conference.West },
                new Team { Id = 22, Name = "Los Angeles Clippers", City = "Los Angeles", Abbreviation = "LAC", Conference = Conference.West },
                new Team { Id = 23, Name = "Los Angeles Lakers", City = "Los Angeles", Abbreviation = "LAL", Conference = Conference.West },
                new Team { Id = 24, Name = "Phoenix Suns", City = "Phoenix", Abbreviation = "PHX", Conference = Conference.West },
                new Team { Id = 25, Name = "Sacramento Kings", City = "Sacramento", Abbreviation = "SAC", Conference = Conference.West },
                new Team { Id = 26, Name = "Dallas Mavericks", City = "Dallas", Abbreviation = "DAL", Conference = Conference.West },
                new Team { Id = 27, Name = "Houston Rockets", City = "Houston", Abbreviation = "HOU", Conference = Conference.West },
                new Team { Id = 28, Name = "Memphis Grizzlies", City = "Memphis", Abbreviation = "MEM", Conference = Conference.West },
                new Team { Id = 29, Name = "New Orleans Pelicans", City = "New Orlean", Abbreviation = "NOP", Conference = Conference.West },
                new Team { Id = 30, Name = "San Antonio Spurs", City = "San Antonio", Abbreviation = "SAS", Conference = Conference.West }
            };
        }
    }
}