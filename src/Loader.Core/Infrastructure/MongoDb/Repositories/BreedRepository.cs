using Loader.Core.Domain.Models;
using Loader.Core.Domain.Repositories;

namespace Loader.Core.Infrastructure.MongoDb.Repositories;

public class BreedRepository : MongoDbRepositoryBase<Breed, Guid>, IBreedRepository
{
    public BreedRepository(MongoDbContextProvider context) : base(context) { }
}
