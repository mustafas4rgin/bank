using Microsoft.EntityFrameworkCore;

namespace QueueTrials;

public class AppDbContext : DbContext
{
    public DbSet<Customer> customers {get; set;}
    public DbSet<Security> securities{get; set;}
    public DbSet<Officer> officers{get; set;}
    public DbSet<Order> orders{get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=bank.db");
    }
}
