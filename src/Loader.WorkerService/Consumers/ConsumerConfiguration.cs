namespace Loader.WorkerService.Consumers;

public class ConsumerConfiguration : IConsumerConfiguration
{
    private readonly IConfiguration _configuration;

    public ConsumerConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string URL => GetUrl();

    public string Token => GetToken();

    public string Header => GetHeader();

    private string GetUrl()
    {
        return _configuration.GetSection("DataSource:BaseURL")?.Value ?? string.Empty;
    }

    private string GetToken()
    {
        return _configuration.GetSection("DataSource:Token")?.Value ?? string.Empty;
    }

    private string GetHeader()
    {
        return _configuration.GetSection("DataSource:Header")?.Value ?? string.Empty;
    }
}
