using Loader.Core.Data.DB.Repositories;
using Loader.Core.Domain.Models;
using Loader.Core.Domain.UseCases;

namespace Loader.Core.Data.UseCases;

public class LoadBreeds : ILoadBreeds
{
  private readonly IBreedRepository _repository;

  public LoadBreeds(IBreedRepository repository)
  {
    _repository = repository;
  }

  public async Task<bool> Import(IEnumerable<Breed> breeds)
  {
    var response = false;

    try
    {
      foreach (var breed in breeds)
      {
        var breedExists = await _repository.ExistsAsync(breed);

        if (breedExists)
        {
          await _repository.UpdateAsync(breed);
        }
        else
        {
          await _repository.InsertAsync(breed);
        }
      }
      response = true;
    }
    catch (Exception ex)
    {
      response = false;
    }

    return response;
  }
}
