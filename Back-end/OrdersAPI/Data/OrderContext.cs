//Payment has been implemented as part of the order context as (as the app stands now)
// a payment will always be part of an order. If I was to re-do this I'd have payments
// as a completely separate service and API

using Microsoft.EntityFrameworkCore;
namespace OrdersAPI.Models;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;



}