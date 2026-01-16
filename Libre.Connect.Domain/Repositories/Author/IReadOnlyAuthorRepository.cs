using Libre.Connect.Domain.Entites.ValueObject;

namespace Libre.Connect.Domain.Repositories.Author;

public interface IReadOnlyAuthorRepository
{
    Task<Entites.Author?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid Id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Entites.Author>> GetAllAsync(CancellationToken cancellationToken = default);
    
}