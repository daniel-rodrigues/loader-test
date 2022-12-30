using Loader.Core.Domain.Models;
using Loader.Core.Domain.UseCases;
using Newtonsoft.Json;

namespace Loader.WorkerService.Consumers;

public class BreedConsumer : IBreedConsumer
{
    private readonly IConsumerConfiguration _consumerConfiguration;
    private readonly ILoadBreeds _loadBreeds;

    private readonly HttpClient _client;
    public BreedConsumer(IConsumerConfiguration consumerConfiguration, ILoadBreeds loadBreeds)
    {
        _consumerConfiguration = consumerConfiguration;
        _loadBreeds = loadBreeds;
        _client = new HttpClient();
    }

    public async Task Consume()
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            _consumerConfiguration.URL);

        using var response = await _client.SendAsync(request);
        var stringJson = await response.Content.ReadAsStringAsync();
        var test = JsonConvert.DeserializeObject<IEnumerable<Breed>>(stringJson);
    }
}

