using Microsoft.Extensions.Logging;

namespace Loader.Core.Infrastructure.Exceptions;

public class EntityNotFoundException : BusinessException
{
    public Type EntityType { get; set; }
    public object? Id { get; set; }

    public EntityNotFoundException(Type entityType) : this(entityType, null, null, null)
    {
    }

    public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null, null)
    {
    }

    public EntityNotFoundException(Type entityType, object? id = null, Exception? innerException = null, string? message = null)
            : base(LogLevel.Warning, innerException, message ?? ("There is no such an entity. Entity type: " + ((id != null) ? $"{entityType.FullName} - Id: {id}" : entityType.FullName)))
    {
        EntityType = entityType;
        Id = id;
    }
}
