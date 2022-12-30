using Microsoft.Extensions.Configuration;

namespace Loader.Core.Infrastructure.MongoDb;

public class MongoDbConfiguration : IMongoDbConfiguration
{
    private IConfiguration _configuration;

    public MongoDbConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => GetConnectionString();
    public string DatabaseName => GetDatabaseName();

    private string GetConnectionString()
    {
        return _configuration.GetSection("MongoDb:ConnectionString").Value;
    }

    private string GetDatabaseName()
    {
        return _configuration.GetSection("MongoDb:DatabaseName").Value;
    }
}
