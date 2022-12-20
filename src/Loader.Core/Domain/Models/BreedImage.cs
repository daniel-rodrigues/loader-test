namespace Loader.Core.Domain.Models;

public class BreedImage
{
    public BreedImage(string uRL, string externalId)
    {
        URL = uRL;
        ExternalId = externalId;
    }

    public string URL { get; set; }
    public string ExternalId { get; set; }
}