using Microsoft.EntityFrameworkCore;
namespace OrdersAPI.Models;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; }



}