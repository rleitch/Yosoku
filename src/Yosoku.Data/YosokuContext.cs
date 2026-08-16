using Microsoft.EntityFrameworkCore;
using Yosoku.Data.Entities;

namespace Yosoku.Data;

public class YosokuContext(DbContextOptions<YosokuContext> options) : DbContext(options)
{
    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>()
            .HasKey(r => new { r.Ticker, r.Date });

        modelBuilder.Entity<Record>()
            .Property(r => r.Ticker)
            .HasMaxLength(10);

        base.OnModelCreating(modelBuilder);
    }
}