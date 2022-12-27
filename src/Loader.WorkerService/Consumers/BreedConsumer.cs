using Loader.Core.Domain.Models;
using Loader.Core.Infrastructure.Consumers;

namespace Loader.WorkerService.Consumers
{
    public class BreedConsumer : IBreedConsumer
    {
        private readonly IConsumerConfiguration _consumerConfiguration;
        private readonly ILoadBreeds _loadBreeds;
        public BreedConsumer(IConsumerConfiguration consumerConfiguration)
        {
            _consumerConfiguration = consumerConfiguration;
        }

        public Task GetData()
        {
            throw new NotImplementedException();
        }
    }
}
