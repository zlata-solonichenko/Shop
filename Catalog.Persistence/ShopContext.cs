using Catalog.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Persistence;

public class ShopContext : DbContext
{
    public DbSet<TovarDb> Tovars { get; set; } // Таблица Tovars

    public ShopContext(){}

    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурации моделей
        modelBuilder.Entity<TovarDb>().HasKey(u => u.Id);
    }
}

public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
{
    public ShopContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shop;Username=postgres;Password=postgres");
        
        return new ShopContext(optionsBuilder.Options);
    }
}