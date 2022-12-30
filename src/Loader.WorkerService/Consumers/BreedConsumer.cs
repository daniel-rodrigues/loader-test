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
        breeds = breeds.Select(breed => GetBreedImages(breed).Result);

        if (breeds == null || !breeds.Any())
        {
            _logger.LogInformation("Data not found");
            return;
        }

        await _breedAppService.Import(breeds);
    }

    private async Task<IEnumerable<BreedDto>> GetBreedsAsync()
    {
        return await Request<BreedDto>($"{_consumerConfiguration.URL}/breeds?limit=100");
    }

    private async Task<BreedDto> GetBreedImages(BreedDto breedDto)
    {
        var images = await Request<BreedImageDto>($"{_consumerConfiguration.URL}/images/search?format=json&limit=3&breed_ids={breedDto.Id}");

        if(images != null && images.Count() > 0)
            breedDto.AddImages(images); 

        return breedDto;
    }

    private async Task<IEnumerable<T>> Request<T>(string url) where T : class
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            url);

        using var response = await _client.SendAsync(request);
        var stringJson = await response.Content.ReadAsStringAsync();
        IEnumerable<T> data = JsonConvert.DeserializeObject<IEnumerable<T>>(stringJson);
        return data;
    }
}

