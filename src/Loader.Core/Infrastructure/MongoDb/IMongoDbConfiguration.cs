namespace Loader.Core.Infrastructure.MongoDb
{
    public interface IMongoDbConfiguration
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}
