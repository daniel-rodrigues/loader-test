using Loader.Core.Domain.Models;

namespace Loader.Core.Domain.UseCases;

public interface IAddBreed
{
    Task<bool> Add(Breed breed);
}
