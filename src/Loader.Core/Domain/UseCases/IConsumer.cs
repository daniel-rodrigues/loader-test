namespace Loader.Core.Domain.UseCases;

public interface IConsumer<TEntity>
{
    Task<IEnumerable<TEntity>> GetData();
}
