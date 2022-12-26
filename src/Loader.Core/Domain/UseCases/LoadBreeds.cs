using Loader.Core.Domain.Models;
using Loader.Core.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Loader.Core.Domain.UseCases;

public class LoadBreeds : ILoadBreeds
{
    private readonly IBreedRepository _repository;
    private readonly ILogger<LoadBreeds> _logger;

    public LoadBreeds(IBreedRepository repository, ILogger<LoadBreeds> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public virtual IQueryable<Breed> Breeds => _repository.ListAll();

    public async Task<bool> Import(IEnumerable<Breed> breeds)
    {
        bool response;
        try
        {
            foreach (var breed in breeds)
            {
                var breedExists = Exists(breed);

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
            _logger.LogError(ex, $"LoadBreeds - Import - {DateTime.Now:yyyy-MM-dd hh:mm:ss}");
            response = false;
        }

        return response;
    }

    private bool Exists(Breed breed)
    {
        return (Breeds.FirstOrDefault(p => p.ExternalId == breed.ExternalId) != null);
    }
}
