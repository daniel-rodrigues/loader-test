using Loader.Core.Domain.Models;
using Loader.Core.Domain.UseCases;

namespace Loader.Core.Data.UseCases;

public class AddBreed : IAddBreed
{
    public Task<bool> Add(Breed breed)
    {
        return Task.FromResult(true);
    }
}
