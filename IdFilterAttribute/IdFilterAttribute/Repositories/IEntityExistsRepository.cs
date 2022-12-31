namespace IdFilterAttribute.Repositories;

public interface IEntityExistsRepository
{
    Task<bool> IsExists(Object? id);
}