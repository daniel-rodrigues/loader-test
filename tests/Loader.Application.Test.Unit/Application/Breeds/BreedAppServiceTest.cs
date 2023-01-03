using Loader.Application.Breeds;
using Loader.Application.Breeds.Dto;
using Loader.Core.Domain.Models;
using Loader.Core.Domain.UseCases;
using Moq;
using Xunit;

namespace Loader.Test.Unit.Application.Breeds;

public class BreedAppServiceTest
{
    private readonly BreedAppService breedAppService;
    private readonly Mock<ILoadBreeds> _loadBreedsMock = new();
    private readonly Mock<IBreedMapper> _mapperMock = new();

    public BreedAppServiceTest()
    {
        breedAppService = MakeAppServiceSut();
    }


    [Fact(DisplayName = "Deve importar dados de raças")]
    [Trait("BreedAppService", "Import")]
    public async Task ShouldImportBreeds()
    {
        var breeds = new List<BreedDto> { new BreedDto() };

        await breedAppService.Import(breeds);

        _mapperMock
            .Verify(v => v.Map(It.IsAny<IEnumerable<BreedDto>>()), Times.Once());
        _loadBreedsMock
            .Verify(v => v.Import(It.IsAny<IEnumerable<Breed>>()), Times.Once());
    }

    private BreedAppService MakeAppServiceSut()
    {
        _loadBreedsMock
            .Setup(s => s.Import(It.IsAny<IEnumerable<Breed>>()));

        _mapperMock
            .Setup(s => s.Map(It.IsAny<IEnumerable<BreedDto>>()))
            .Returns(Enumerable.Empty<Breed>());

        return new BreedAppService(_loadBreedsMock.Object, _mapperMock.Object);
    }
}
