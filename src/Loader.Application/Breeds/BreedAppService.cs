using Loader.Application.Breeds.Dto;
using Loader.Core.Domain.Models;
using Loader.Core.Domain.UseCases;

namespace Loader.Application.Breeds;

public class BreedAppService : IBreedAppService
{
    private readonly ILoadBreeds _loadBreeds;

	public BreedAppService(ILoadBreeds loadBreeds)
	{
        _loadBreeds = loadBreeds;
	}

    public async Task Import(IEnumerable<BreedDto> breeds)
    {
        await _loadBreeds.Import(Map(breeds));
    }

    private IEnumerable<Breed> Map(IEnumerable<BreedDto> breedDtos)
    {
        return breedDtos.Select(Map);
    }

    private Breed Map(BreedDto breedDto)
    {
        return new Breed(
            breedDto.Description,
            breedDto.Origin,
            breedDto.Temperament,
            breedDto.Id)
        {
            Images = Map(breedDto.Images)
        };
    }

    private IEnumerable<BreedImage> Map(IEnumerable<BreedImageDto> imageDtos)
    {
        return imageDtos.Select(Map);
    }

    private BreedImage Map(BreedImageDto imageDto)
    {
        return new BreedImage(imageDto.URL, imageDto.Id);
    }
}

