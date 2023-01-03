using Loader.Application.Breeds;
using Loader.Application.Breeds.Dto;
using Loader.Core.Domain.Models;
using Xunit;

namespace Loader.Test.Unit.Application.Breeds
{
    public class BreedMapperTest
    {
        private readonly BreedMapper _breedMapper;

        public BreedMapperTest()
        {
            _breedMapper = MakeSut();
        }

        [Fact(DisplayName = "Deve retornar um enumerador de raças")]
        [Trait("BreedMapper", "Map")]
        public void ShouldReturnAnEnumerableOfBreed()
        {
            var breeds = new List<BreedDto> { new BreedDto() };
            var result = _breedMapper.Map(breeds);

            Assert.True(typeof(IEnumerable<Breed>).IsAssignableFrom(result.GetType()));
        }

        [Fact(DisplayName = "Deve retornar uma de raça")]
        [Trait("BreedMapper", "Map")]
        public void ShouldReturnABreed()
        {
            var breed = new BreedDto();
            var result = _breedMapper.Map(breed);

            Assert.True(result.GetType() == typeof(Breed));
        }

        [Fact(DisplayName = "Deve retornar um enumerador de imagens da raça")]
        [Trait("BreedMapper", "Map")]
        public void ShouldReturnAnEnumerableOfBreedImage()
        {
            var breedImages = new List<BreedImageDto>();
            var result = _breedMapper.Map(breedImages);

            Assert.True(typeof(IEnumerable<BreedImage>).IsAssignableFrom(result.GetType()));
        }

        [Fact(DisplayName = "Deve retornar uma imagem da raça")]
        [Trait("BreedMapper", "Map")]
        public void ShouldReturnABreedImage()
        {
            var breedImage = new BreedImageDto();
            var result = _breedMapper.Map(breedImage);

            Assert.True(result.GetType() == typeof(BreedImage));
        }

        private BreedMapper MakeSut()
        {
            return new BreedMapper();
        }
    }
}
