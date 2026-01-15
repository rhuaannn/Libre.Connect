using Libre.Connect.Domain.Entites;

namespace Libre.Connect.Domain.Repositories;

public interface IReadOnlyBookRepository
{
    Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default);
}