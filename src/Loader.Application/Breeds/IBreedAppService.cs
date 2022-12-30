using Loader.Application.Breeds.Dto;

namespace Loader.Application.Breeds;

public interface IBreedAppService
{
    Task Import(IEnumerable<BreedDto> breeds);
}

