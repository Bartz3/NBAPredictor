using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NBAPredictor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LogicAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    YearStart = table.Column<int>(type: "integer", nullable: false),
                    YearEnd = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserScores_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserScores_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    Losses = table.Column<int>(type: "integer", nullable: false),
                    ActualRank = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeasonResults_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonResults_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Conference = table.Column<int>(type: "integer", nullable: false),
                    PredictedRank = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBets_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBets_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBets_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "IsActive", "Name", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 1, false, "2024/25", 2025, 2024 },
                    { 2, true, "2025/26", 2026, 2025 },
                    { 3, false, "2026/27", 2027, 2026 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Abbreviation", "City", "Conference", "Name" },
                values: new object[,]
                {
                    { 1, "BOS", "Boston", 0, "Boston Celtics" },
                    { 2, "BKN", "New York", 0, "Brooklyn Nets" },
                    { 3, "NYK", "New York", 0, "New York Knicks" },
                    { 4, "PHI", "Philadelphia", 0, "Philadelphia 76ers" },
                    { 5, "TOR", "Toronto", 0, "Toronto Raptors" },
                    { 6, "CHI", "Chicago", 0, "Chicago Bulls" },
                    { 7, "CLE", "Cleveland", 0, "Cleveland Cavaliers" },
                    { 8, "DET", "Detroit", 0, "Detroit Pistons" },
                    { 9, "IND", "Indianapolis", 0, "Indiana Pacers" },
                    { 10, "MIL", "Milwaukee", 0, "Milwaukee Bucks" },
                    { 11, "ATL", "Atlanta", 0, "Atlanta Hawks" },
                    { 12, "CHA", "Charlotte", 0, "Charlotte Hornets" },
                    { 13, "MIA", "Miami", 0, "Miami Heat" },
                    { 14, "ORL", "Orlando", 0, "Orlando Magic" },
                    { 15, "WAS", "Washington", 0, "Washington Wizards" },
                    { 16, "DEN", "Denver", 1, "Denver Nuggets" },
                    { 17, "MIN", "Minneapolis", 1, "Minnesota Timberwolves" },
                    { 18, "OKC", "Oklahoma City", 1, "Oklahoma City Thunder" },
                    { 19, "POR", "Portland", 1, "Portland Trail Blazers" },
                    { 20, "UTA", "Salt Lake City", 1, "Utah Jazz" },
                    { 21, "GSW", "San Francisco", 1, "Golden State Warriors" },
                    { 22, "LAC", "Los Angeles", 1, "Los Angeles Clippers" },
                    { 23, "LAL", "Los Angeles", 1, "Los Angeles Lakers" },
                    { 24, "PHX", "Phoenix", 1, "Phoenix Suns" },
                    { 25, "SAC", "Sacramento", 1, "Sacramento Kings" },
                    { 26, "DAL", "Dallas", 1, "Dallas Mavericks" },
                    { 27, "HOU", "Houston", 1, "Houston Rockets" },
                    { 28, "MEM", "Memphis", 1, "Memphis Grizzlies" },
                    { 29, "NOP", "New Orlean", 1, "New Orleans Pelicans" },
                    { 30, "SAS", "San Antonio", 1, "San Antonio Spurs" }
                });

            migrationBuilder.InsertData(
                table: "SeasonResults",
                columns: new[] { "Id", "ActualRank", "Conference", "Losses", "SeasonId", "TeamId", "Wins" },
                values: new object[,]
                {
                    { 1, 1, 0, 18, 1, 7, 64 },
                    { 2, 2, 0, 21, 1, 1, 61 },
                    { 3, 3, 0, 31, 1, 3, 51 },
                    { 4, 4, 0, 32, 1, 9, 50 },
                    { 5, 5, 0, 34, 1, 10, 48 },
                    { 6, 6, 0, 38, 1, 8, 44 },
                    { 7, 7, 0, 41, 1, 14, 41 },
                    { 8, 8, 0, 42, 1, 11, 40 },
                    { 9, 9, 0, 43, 1, 6, 39 },
                    { 10, 10, 0, 45, 1, 13, 37 },
                    { 11, 11, 0, 52, 1, 5, 30 },
                    { 12, 12, 0, 56, 1, 2, 26 },
                    { 13, 13, 0, 58, 1, 4, 24 },
                    { 14, 14, 0, 63, 1, 12, 19 },
                    { 15, 15, 0, 64, 1, 15, 18 },
                    { 16, 1, 1, 14, 1, 18, 68 },
                    { 17, 2, 1, 30, 1, 27, 52 },
                    { 18, 3, 1, 32, 1, 23, 50 },
                    { 19, 4, 1, 32, 1, 16, 50 },
                    { 20, 5, 1, 32, 1, 22, 50 },
                    { 21, 6, 1, 33, 1, 17, 49 },
                    { 22, 7, 1, 34, 1, 21, 48 },
                    { 23, 8, 1, 34, 1, 28, 48 },
                    { 24, 9, 1, 42, 1, 25, 40 },
                    { 25, 10, 1, 43, 1, 26, 39 },
                    { 26, 11, 1, 46, 1, 24, 36 },
                    { 27, 12, 1, 46, 1, 19, 36 },
                    { 28, 13, 1, 48, 1, 30, 34 },
                    { 29, 14, 1, 61, 1, 29, 21 },
                    { 30, 15, 1, 65, 1, 20, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonResults_SeasonId",
                table: "SeasonResults",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonResults_TeamId",
                table: "SeasonResults",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_SeasonId",
                table: "UserBets",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_TeamId",
                table: "UserBets",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_UserId1",
                table: "UserBets",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_SeasonId",
                table: "UserScores",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_UserId1",
                table: "UserScores",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonResults");

            migrationBuilder.DropTable(
                name: "UserBets");

            migrationBuilder.DropTable(
                name: "UserScores");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
