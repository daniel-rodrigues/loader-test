using Loader.Application.Breeds;
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
        services.AddSingleton<IConsumerConfiguration, ConsumerConfiguration>();
        services.AddSingleton<IBreedConsumer, BreedConsumer>();
        services.AddSingleton<IBreedAppService, BreedAppService>();
        services.AddSingleton<ILoadBreeds, LoadBreeds>();
        services.AddSingleton<IBreedRepository, BreedRepository>();
        services.AddSingleton<IMongoDbConfiguration, MongoDbConfiguration>();
        services.AddSingleton<MongoDbContextProvider>();
        
    })
    .Build();

await host.RunAsync();
