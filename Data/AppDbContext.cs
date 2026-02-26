using Microsoft.EntityFrameworkCore;
using sdev2301_a1_ZorawarSinghRandhawa.Entities;

namespace sdev2301_a1_ZorawarSinghRandhawa.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=school.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasIndex(c => c.Code)
            .IsUnique();
    }
}