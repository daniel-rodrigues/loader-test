namespace Loader.Application.Breeds.Dto;

public class BreedDto
{
    public BreedDto()
    {
        Id = string.Empty;
        Description = string.Empty;
        Origin = string.Empty;
        Temperament = string.Empty;
    }

    public BreedDto(string id, string description, string origin, string temperament)
    {
        Id = id;
        Description = description;
        Origin = origin;
        Temperament = temperament;
    }

    public string Id { get; set; }
    public string Description { get; set; }
    public string Origin { get; set; }
    public string Temperament { get; set; }
    public IEnumerable<BreedImageDto> Images { get; set; } = new List<BreedImageDto>();

    public void AddImages(IEnumerable<BreedImageDto> images)
    {
        Images = images;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Images: {Images.Count()}";
    }
}

