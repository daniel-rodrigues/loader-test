using Loader.Core.Domain.Models;

namespace Loader.Core.Domain.UseCases;

public interface ILoadBreeds
{
    Task<bool> Import(IEnumerable<Breed> breeds);
}
