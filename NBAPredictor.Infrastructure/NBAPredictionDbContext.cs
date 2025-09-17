using NBAPredictor.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NBAPredictor.Infrastructure;

public class NBAPredictionDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public NBAPredictionDbContext(DbContextOptions<NBAPredictionDbContext> options) : base(options){}
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>()
            .Property(u => u.UserName).HasMaxLength(128);
    }
}