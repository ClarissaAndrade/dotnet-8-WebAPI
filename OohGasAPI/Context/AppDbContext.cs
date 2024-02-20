using Microsoft.EntityFrameworkCore;
using OohGasAPI.Models;

namespace OohGasAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Deliverer>? Deliverers { get; set; }

}
