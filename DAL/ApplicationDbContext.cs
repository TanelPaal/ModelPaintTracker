using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<PaintType> PaintTypes { get; set; } = null!;
    public DbSet<Paint> Paints { get; set; } = null!;
    public DbSet<Faction> Factions { get; set; } = null!;
    public DbSet<State> States { get; set; } = null!;
    public DbSet<Model> Models { get; set; } = null!;
    public DbSet<ModelPaint> ModelPaints { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure composite key for ModelPaint
        modelBuilder.Entity<ModelPaint>()
            .HasKey(mp => new { mp.ModelID, mp.PaintID });

        // Configure relationships
        modelBuilder.Entity<ModelPaint>()
            .HasOne(mp => mp.Model)
            .WithMany(m => m.ModelPaints)
            .HasForeignKey(mp => mp.ModelID);

        modelBuilder.Entity<ModelPaint>()
            .HasOne(mp => mp.Paint)
            .WithMany(p => p.ModelPaints)
            .HasForeignKey(mp => mp.PaintID);
    }
}
