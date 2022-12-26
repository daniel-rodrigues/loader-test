using Loader.Core.Domain.Models;
using Loader.Core.Domain.UseCases;

namespace Loader.WorkerService.Consumers
{
    public interface IBreedConsumer : IConsumer<Breed>
    {
    }
}
