using Loader.Application.Breeds.Dto;
using Loader.Core.Domain.UseCases;

namespace Loader.Application.Breeds;

public class BreedAppService : IBreedAppService
{
    private readonly ILoadBreeds _loadBreeds;
    private readonly IBreedMapper _mapper;

    public BreedAppService(ILoadBreeds loadBreeds, IBreedMapper mapper)
    {
        _loadBreeds = loadBreeds;
        _mapper = mapper;
    }

    public async Task Import(IEnumerable<BreedDto> breeds)
    {
        await _loadBreeds.Import(_mapper.Map(breeds));
    }
}

