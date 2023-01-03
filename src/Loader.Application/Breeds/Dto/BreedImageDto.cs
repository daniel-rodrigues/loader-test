
namespace Loader.Application.Breeds.Dto;

public class BreedImageDto
{
    public BreedImageDto()
    {
        URL = string.Empty;
        Id = string.Empty;
    }

    public BreedImageDto(string uRL, string id)
    {
        URL = uRL;
        Id = id;
    }

    public string URL { get; set; }
    public string Id { get; set; }
}

