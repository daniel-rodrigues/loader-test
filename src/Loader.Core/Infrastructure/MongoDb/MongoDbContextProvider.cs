using MongoDB.Driver;

namespace Loader.Core.Infrastructure.MongoDb;

public class MongoDbContextProvider
{
    private readonly IMongoDbConfiguration _configuration;
    public IMongoDatabase Database { get; private set; }

    public MongoDbContextProvider(IMongoDbConfiguration configuration)
    {
        _configuration = configuration;
        MongoClient mongoClient = new MongoClient(_configuration.ConnectionString);
        Database = mongoClient.GetDatabase(_configuration.DatabaseName);
    }

    public virtual IMongoCollection<T> Collection<T>()
    {
        return Database.GetCollection<T>(typeof(T).Name);
    }
}
