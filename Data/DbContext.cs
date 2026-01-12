using Microsoft.EntityFrameworkCore;
using GameCollectionPlayApi.Models;

namespace GameCollectionPlayApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Game { get; set; }
    public DbSet<Gender> Gender { get; set; }
    public DbSet<Platform> Platform { get; set; }
    public DbSet<Status> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // GamePlatform N:N
        modelBuilder.Entity<GamePlatform>()
            .HasKey(gp => new { gp.GameId, gp.PlatformId });

        modelBuilder.Entity<GamePlatform>()
            .HasOne(gp => gp.Game)
            .WithMany(g => g.GamePlatforms)
            .HasForeignKey(gp => gp.GameId);

        modelBuilder.Entity<GamePlatform>()
            .HasOne(gp => gp.Platform)
            .WithMany(p => p.GamePlatforms)
            .HasForeignKey(gp => gp.PlatformId);

        // GameGender N:N
        modelBuilder.Entity<GameGender>()
            .HasKey(gg => new { gg.GameId, gg.GenderId });

        modelBuilder.Entity<GameGender>()
            .HasOne(gg => gg.Game)
            .WithMany(g => g.GameGenders)
            .HasForeignKey(gg => gg.GameId);

        modelBuilder.Entity<GameGender>()
            .HasOne(gg => gg.Gender)
            .WithMany(g => g.GameGenders)
            .HasForeignKey(gg => gg.GenderId);
    }
}
