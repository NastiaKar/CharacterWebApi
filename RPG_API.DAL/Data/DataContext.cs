using Microsoft.EntityFrameworkCore;
using RPG_API.DAL.Entities;

namespace RPG_API.DAL.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Weapon> Weapons { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(character =>
        {
            character
                .HasOne(c => c.Weapon)
                .WithOne(w => w.Character);
            character
                .HasMany(c => c.Skills)
                .WithMany(s => s.Characters);
        });
    }
}