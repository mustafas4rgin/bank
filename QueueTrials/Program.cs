using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using QueueTrials;

internal class Program
{
    private static void Main(string[] args)
    {
        App bankApp = new App();

        Seeder seeder = new Seeder();

        var serviceProvider = new ServiceCollection()
        .AddDbContext<AppDbContext>()
        .BuildServiceProvider();
        var context = serviceProvider.GetService<AppDbContext>();

        seeder.FakeData(context);

        while(true){
            bankApp.Run(context);
        }
    }
}