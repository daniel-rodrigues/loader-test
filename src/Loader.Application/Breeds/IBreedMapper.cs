using Loader.Application.Breeds.Dto;
using Loader.Core.Domain.Models;

namespace Loader.Application.Breeds
{
    public interface IBreedMapper
    {
        IEnumerable<Breed> Map(IEnumerable<BreedDto> breedDtos);

        Breed Map(BreedDto breedDto);

        IEnumerable<BreedImage> Map(IEnumerable<BreedImageDto> imageDtos);

        BreedImage Map(BreedImageDto imageDto);
    }
}