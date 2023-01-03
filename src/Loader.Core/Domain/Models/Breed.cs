namespace Loader.Core.Domain.Models;

public class Breed : Entity<Guid>
{
    public Breed()
    {
        Id = Guid.Empty;
        Description = string.Empty;
        Origin = string.Empty;
        Temperament = string.Empty;
        ExternalId = string.Empty;
    }

    public Breed(string description, string origin, string temperament, string externalId)
    {
        Description = description;
        Origin = origin;
        Temperament = temperament;
        ExternalId = externalId;
    }

    public string Description { get; set; }
    public string Origin { get; set; }
    public string Temperament { get; set; }
    public string ExternalId { get; set; }
    public IEnumerable<BreedImage> Images { get; set; } = new List<BreedImage>();

    public void AddImages(IEnumerable<BreedImage> images)
    {
        Images = images;
    }

    public override string ToString()
    {
        return $"ExternalId: {ExternalId} - Images: {Images.Count()}";
    }
}
