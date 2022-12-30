using Loader.Application.Breeds;
using Loader.Application.Breeds.Dto;
using Newtonsoft.Json;

namespace Loader.WorkerService.Consumers;

public class BreedConsumer : IBreedConsumer
{
    private readonly IConsumerConfiguration _consumerConfiguration;
    private readonly IBreedAppService _breedAppService;
    private readonly ILogger<BreedConsumer> _logger;
    private readonly HttpClient _client;
    public BreedConsumer(IConsumerConfiguration consumerConfiguration, IBreedAppService breedAppService, ILogger<BreedConsumer> logger)
    {
        _consumerConfiguration = consumerConfiguration;
        _breedAppService = breedAppService;
        _logger = logger;
        _client = new HttpClient();
    }

    public async Task Consume()
    {
        var breeds = await GetBreedsAsync();

        if (breeds == null || !breeds.Any())
        {
            _logger.LogInformation("Data not found");
            return;
        }

        await _breedAppService.Import(breeds);
    }

    private async Task<IEnumerable<BreedDto>> GetBreedsAsync()
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"{_consumerConfiguration.URL}/breeds?limit=100");

        using var response = await _client.SendAsync(request);
        var stringJson = await response.Content.ReadAsStringAsync();
        IEnumerable<BreedDto> breeds = JsonConvert.DeserializeObject<IEnumerable<BreedDto>>(stringJson);
        return breeds;
    }
}

