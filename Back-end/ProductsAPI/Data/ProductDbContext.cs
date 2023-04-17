using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
     : base(options)
    {
        Database.ExecuteSqlRaw("PRAGMA synchronous = FULL;");
        Database.ExecuteSqlRaw("PRAGMA journal_mode = WAL;");
    }

    public DbSet<Product> Products { get; set; } = null!;

}