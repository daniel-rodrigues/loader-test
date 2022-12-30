using Loader.Core.Domain.Repositories;
using Loader.Core.Domain.UseCases;
using Loader.Core.Infrastructure.MongoDb;
using Loader.Core.Infrastructure.MongoDb.Repositories;
using Loader.WorkerService;
using Loader.WorkerService.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddScoped<IBreedConsumer, BreedConsumer>();
        services.AddScoped<IConsumerConfiguration, ConsumerConfiguration>();
        services.AddScoped<ILoadBreeds, LoadBreeds>();
        services.AddScoped<IBreedRepository, BreedRepository>();
        services.AddScoped<IMongoDbConfiguration, MongoDbConfiguration>();
        services.AddSingleton<MongoDbContextProvider>();
        
    })
    .Build();

await host.RunAsync();
