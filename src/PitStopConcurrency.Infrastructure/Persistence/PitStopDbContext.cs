using Microsoft.EntityFrameworkCore;
using PitStopConcurrency.Domain.Entities;

namespace PitStopConcurrency.Infrastructure.Persistence;

public class PitStopDbContext : DbContext
{
    public PitStopDbContext(DbContextOptions<PitStopDbContext> options)
        : base(options) { }

    public DbSet<Race> Races { get; set; }
    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações adicionais de mapeamento, se necessário
        // Por exemplo:
        // modelBuilder.Entity<Race>()
        //     .HasMany(r => r.Cars)
        //     .WithOne()
        //     .HasForeignKey(c => c.RaceId);
    }
}
