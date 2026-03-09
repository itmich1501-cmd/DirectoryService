using DirectionService.Domain.Departaments;
using Microsoft.EntityFrameworkCore;

namespace DirectionService.Infrastructure.Postgres;

public class DepartmentServiceDbContext : DbContext
{
    private readonly string _connectionString;

    public DepartmentServiceDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentServiceDbContext).Assembly);
    }

    public DbSet<Departament> Departaments => Set<Departament>();
}