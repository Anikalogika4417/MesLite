using MesLite.Models;
using Microsoft.EntityFrameworkCore;

namespace MesLite.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public DbSet<ProductionLine> ProductionLines { get; set; }
    public DbSet<Batch> Batches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductionLine>()
            .HasKey(line => line.LineId);

        modelBuilder.Entity<Batch>()
            .HasKey(line => line.BatchId);

        modelBuilder.Entity<Batch>()
            .HasOne(b => b.Line)
            .WithMany(l => l.Batches)
            .HasForeignKey(b => b.LineId);
    }
}
