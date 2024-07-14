using Microsoft.EntityFrameworkCore;

namespace HomeWork0603.Data;

public class MaserDataContext : DbContext
{
    private readonly string _connectionString;

    public MaserDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    public DbSet<Income> Incomes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Source> Sources { get; set; }
}