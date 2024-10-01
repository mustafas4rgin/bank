using Microsoft.Extensions.DependencyInjection;

namespace QueueTrials;

public class Seeder
{
     public void FakeData(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        context.officers.Add(new Officer
        {
            OfficerId = 1,
            Name = "Mustafa",
            Username = "admin",
            Password = "admin123",
            IsAdmin = true,
        });
        
        context.customers.Add(new Customer
        {
            Name = "Simoş",
            Address = "Kültür",
            Username = "simos123",
            Password = "simos",
            Balance = 0
        });
        
        context.orders.Add(new Order { CustomerId = 1 });
        context.SaveChanges();
    }
}
