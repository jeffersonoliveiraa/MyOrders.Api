using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyOrders.Domain.Entities.v1;
using MyOrders.Infra.Data.Mapping.v1;

namespace MyOrders.Infra.Data.Context.v1;

public class DbContextClass : DbContext
{
    protected readonly IConfiguration Configuration;

    public DbContextClass(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Order>? Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderMap());

        base.OnModelCreating(modelBuilder);
    }
}
