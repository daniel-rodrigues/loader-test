using Loader.WorkerService.Consumers;

namespace Loader.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IBreedConsumer _consumer;

    public Worker(ILogger<Worker> logger, IBreedConsumer consumer)
    {
        _logger = logger;
        _consumer = consumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await _consumer.GetData();
            await Task.Delay(1000 * 60, stoppingToken);
        }
    }
}
