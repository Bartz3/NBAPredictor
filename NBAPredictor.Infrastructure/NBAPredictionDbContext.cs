using NBAPredictor.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBAPredictor.Domain.Constants;
using NBAPredictor.Infrastructure.Seeders;
using System.Reflection.Emit;

namespace NBAPredictor.Infrastructure;

public class NBAPredictionDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public NBAPredictionDbContext(DbContextOptions<NBAPredictionDbContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<SeasonResult> SeasonResults{ get; set; }
    public DbSet<Team> Teams{ get; set; }
    public DbSet<UserBet> UserBets { get; set; }
    public DbSet<UserScore> UserScores { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>()
            .Property(u => u.UserName).HasMaxLength(128);

        // Adding roles to DB
        builder.Entity<IdentityRole<Guid>>()
            .HasData(new List<IdentityRole<Guid>>
            {
                new IdentityRole<Guid>()
                {
                    Id = IdentityRoleConstants.AdminRoleGuid,
                    Name = IdentityRoleConstants.Admin,
                    NormalizedName = IdentityRoleConstants.Admin.ToUpper()
                },
                new IdentityRole<Guid>()
                {
                    Id = IdentityRoleConstants.UserRoleGuid,
                    Name = IdentityRoleConstants.User,
                    NormalizedName = IdentityRoleConstants.User.ToUpper()
                }
            });

        builder.Entity<Team>().HasData(TeamSeeder.GetTeams());

        builder.Entity<Season>().HasData(
            new Season() {
                Id = 1,
                Name = "2024/25",
                YearStart = 2024,
                YearEnd = 2025,
                IsActive = false
            },
            new Season() {
                Id = 2,
                Name = "2025/26",
                YearStart = 2025,
                YearEnd = 2026,
                IsActive = true
            }, new Season()
            {
                Id = 3,
                Name = "2026/27",
                YearStart = 2026,
                YearEnd = 2027,
                IsActive = false
            });

        builder.Entity<SeasonResult>().HasData(SeasonResultsSeeder.Get202425SeasonResults());

    }
}