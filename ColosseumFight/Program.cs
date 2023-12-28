using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Strategy;

namespace ColosseumFight
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<ColosseumExperimentWorker>();
                    services.AddScoped<ColosseumSandbox>();
                    services.AddScoped<IDeckShuffler, DeckShuffler>();
                    services.AddSingleton(new Player("Elon Musk", new FirstCardStrategy()));
                    services.AddSingleton(new Player("Mark Zuckerberg", new FirstCardStrategy()));
                });
        }
    }
}
