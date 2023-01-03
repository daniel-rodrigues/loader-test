namespace Loader.WorkerService.Consumers;

public interface IConsumerConfiguration
{
    string URL { get; }
    string Token { get; }
    string Header { get; }
}

