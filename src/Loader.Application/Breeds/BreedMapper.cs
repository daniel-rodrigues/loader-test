using Loader.Application.Breeds.Dto;
using Loader.Core.Domain.Models;

namespace Loader.Application.Breeds
{
    public class BreedMapper : IBreedMapper
    {
        public IEnumerable<Breed> Map(IEnumerable<BreedDto> breedDtos)
        {
            return breedDtos.Select(Map);
        }

        public Breed Map(BreedDto breedDto)
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

        public IEnumerable<BreedImage> Map(IEnumerable<BreedImageDto> imageDtos)
        {
            return imageDtos.Select(Map);
        }

        public BreedImage Map(BreedImageDto imageDto)
        {
            return new BreedImage(imageDto.URL, imageDto.Id);
        }
    }
}
