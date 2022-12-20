using Loader.Core.Domain.Models;

namespace Loader.Core.Data.DB.Repositories;

public interface IBreedRepository
{
    Task<bool> InsertAsync(Breed breed);
    Task<bool> UpdateAsync(Breed breed);
    Task<bool> ExistsAsync(Breed breed);
}
