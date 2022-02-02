//using BlazeOrbital.Data;
using BGS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BGS.Data;

internal class ClientSideDbContext : DbContext
{
    public DbSet<Part> Parts { get; set; } = default!;
    public DbSet<Activity> Activities { get; set; } = default!;
    public DbSet<Player> Players { get; set; } = default!;

    public ClientSideDbContext(DbContextOptions<ClientSideDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Part Demo
        modelBuilder.Entity<Part>().HasIndex(nameof(Part.ModifiedTicks), nameof(Part.PartId));
        modelBuilder.Entity<Part>().HasIndex(nameof(Part.Category), nameof(Part.SubCategory));
        modelBuilder.Entity<Part>().HasIndex(x => x.Stock);
        modelBuilder.Entity<Part>().HasIndex(x => x.Name);
        modelBuilder.Entity<Part>().Property(x => x.Name).UseCollation("nocase");
        #endregion

        #region BGS
        modelBuilder.Entity<Activity>().HasIndex(x => x.Id);
        modelBuilder.Entity<Activity>().HasIndex(x => x.Name);
        modelBuilder.Entity<Activity>().Property(x => x.Name).UseCollation("nocase");
        modelBuilder.Entity<Activity>().HasIndex(x => x.Date);
        modelBuilder.Entity<Activity>().HasMany(c => c.Players);

        modelBuilder.Entity<Player>().HasIndex(x => x.Id);
        modelBuilder.Entity<Player>().HasIndex(x => x.Name);
        modelBuilder.Entity<Player>().Property(x => x.Name).UseCollation("nocase");
        modelBuilder.Entity<Player>().HasIndex(x => x.Ranking);
        modelBuilder.Entity<Player>().HasMany(c => c.Activities);
        #endregion
    }
}
