using Microsoft.Extensions.Hosting;

namespace ColosseumFight
{
    public class ColosseumExperimentWorker : BackgroundService
    {
        private const int NumberOfSimulations = 1000000;
        private ColosseumSandbox ColosseumSandbox;

        public ColosseumExperimentWorker(ColosseumSandbox colosseumSandbox)
        {
            ColosseumSandbox = colosseumSandbox;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int numberOfSucceses = 0;

            for (int i = 0; i < NumberOfSimulations; i++)
            {
                bool result = ColosseumSandbox.Simulate();

                if (result)
                    numberOfSucceses++;
            }

            Console.WriteLine((float)numberOfSucceses / NumberOfSimulations);

            return Task.CompletedTask;
        }
    }
}
