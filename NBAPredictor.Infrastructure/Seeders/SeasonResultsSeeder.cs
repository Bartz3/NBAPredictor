using NBAPredictor.Domain.Entities;
using NBAPredictor.Domain.Enums;

namespace NBAPredictor.Infrastructure.Seeders
{
    public class SeasonResultsSeeder
    {
        public static IEnumerable<SeasonResult> Get202425SeasonResults()
        {
            return new List<SeasonResult>
            {
               // EASTERN CONFERENCE
                new SeasonResult { Id = 1, SeasonId = 1, TeamId = 7,  Conference = Conference.East, Wins = 64, Losses = 18, ActualRank = 1 }, // Cleveland Cavaliers
                new SeasonResult { Id = 2, SeasonId = 1, TeamId = 1,  Conference = Conference.East, Wins = 61, Losses = 21, ActualRank = 2 }, // Boston Celtics
                new SeasonResult { Id = 3, SeasonId = 1, TeamId = 3,  Conference = Conference.East, Wins = 51, Losses = 31, ActualRank = 3 }, // New York Knicks
                new SeasonResult { Id = 4, SeasonId = 1, TeamId = 9,  Conference = Conference.East, Wins = 50, Losses = 32, ActualRank = 4 }, // Indiana Pacers
                new SeasonResult { Id = 5, SeasonId = 1, TeamId = 10, Conference = Conference.East, Wins = 48, Losses = 34, ActualRank = 5 }, // Milwaukee Bucks
                new SeasonResult { Id = 6, SeasonId = 1, TeamId = 8,  Conference = Conference.East, Wins = 44, Losses = 38, ActualRank = 6 }, // Detroit Pistons
                new SeasonResult { Id = 7, SeasonId = 1, TeamId = 14, Conference = Conference.East, Wins = 41, Losses = 41, ActualRank = 7 }, // Orlando Magic
                new SeasonResult { Id = 8, SeasonId = 1, TeamId = 11, Conference = Conference.East, Wins = 40, Losses = 42, ActualRank = 8 }, // Atlanta Hawks
                new SeasonResult { Id = 9, SeasonId = 1, TeamId = 6,  Conference = Conference.East, Wins = 39, Losses = 43, ActualRank = 9 }, // Chicago Bulls
                new SeasonResult { Id = 10, SeasonId = 1, TeamId = 13, Conference = Conference.East, Wins = 37, Losses = 45, ActualRank = 10 }, // Miami Heat
                new SeasonResult { Id = 11, SeasonId = 1, TeamId = 5,  Conference = Conference.East, Wins = 30, Losses = 52, ActualRank = 11 }, // Toronto Raptors
                new SeasonResult { Id = 12, SeasonId = 1, TeamId = 2,  Conference = Conference.East, Wins = 26, Losses = 56, ActualRank = 12 }, // Brooklyn Nets
                new SeasonResult { Id = 13, SeasonId = 1, TeamId = 4,  Conference = Conference.East, Wins = 24, Losses = 58, ActualRank = 13 }, // Philadelphia 76ers
                new SeasonResult { Id = 14, SeasonId = 1, TeamId = 12, Conference = Conference.East, Wins = 19, Losses = 63, ActualRank = 14 }, // Charlotte Hornets
                new SeasonResult { Id = 15, SeasonId = 1, TeamId = 15, Conference = Conference.East, Wins = 18, Losses = 64, ActualRank = 15 }, // Washington Wizards

                // WESTERN CONFERENCE
                new SeasonResult { Id = 16, SeasonId = 1, TeamId = 18, Conference = Conference.West, Wins = 68, Losses = 14, ActualRank = 1 }, // OKC Thunder
                new SeasonResult { Id = 17, SeasonId = 1, TeamId = 27, Conference = Conference.West, Wins = 52, Losses = 30, ActualRank = 2 }, // Houston Rockets
                new SeasonResult { Id = 18, SeasonId = 1, TeamId = 23, Conference = Conference.West, Wins = 50, Losses = 32, ActualRank = 3 }, // LA Lakers
                new SeasonResult { Id = 19, SeasonId = 1, TeamId = 16, Conference = Conference.West, Wins = 50, Losses = 32, ActualRank = 4 }, // Denver Nuggets
                new SeasonResult { Id = 20, SeasonId = 1, TeamId = 22, Conference = Conference.West, Wins = 50, Losses = 32, ActualRank = 5 }, // LA Clippers
                new SeasonResult { Id = 21, SeasonId = 1, TeamId = 17, Conference = Conference.West, Wins = 49, Losses = 33, ActualRank = 6 }, // Minnesota Timberwolves
                new SeasonResult { Id = 22, SeasonId = 1, TeamId = 21, Conference = Conference.West, Wins = 48, Losses = 34, ActualRank = 7 }, // Golden State Warriors
                new SeasonResult { Id = 23, SeasonId = 1, TeamId = 28, Conference = Conference.West, Wins = 48, Losses = 34, ActualRank = 8 }, // Memphis Grizzlies
                new SeasonResult { Id = 24, SeasonId = 1, TeamId = 25, Conference = Conference.West, Wins = 40, Losses = 42, ActualRank = 9 }, // Sacramento Kings
                new SeasonResult { Id = 25, SeasonId = 1, TeamId = 26, Conference = Conference.West, Wins = 39, Losses = 43, ActualRank = 10 }, // Dallas Mavericks
                new SeasonResult { Id = 26, SeasonId = 1, TeamId = 24, Conference = Conference.West, Wins = 36, Losses = 46, ActualRank = 11 }, // Phoenix Suns
                new SeasonResult { Id = 27, SeasonId = 1, TeamId = 19, Conference = Conference.West, Wins = 36, Losses = 46, ActualRank = 12 }, // Portland Trail Blazers
                new SeasonResult { Id = 28, SeasonId = 1, TeamId = 30, Conference = Conference.West, Wins = 34, Losses = 48, ActualRank = 13 }, // San Antonio Spurs
                new SeasonResult { Id = 29, SeasonId = 1, TeamId = 29, Conference = Conference.West, Wins = 21, Losses = 61, ActualRank = 14 }, // New Orleans Pelicans
                new SeasonResult { Id = 30, SeasonId = 1, TeamId = 20, Conference = Conference.West, Wins = 17, Losses = 65, ActualRank = 15 }  // Utah Jazz
            };

        }
    }
}
