using Libre.Connect.Domain.Entites;

namespace Libre.Connect.Domain.Repositories;

public interface IWriteOnlyBookRepository
{
    Task AddAsync(Book book);
    Task UpdateAsync(Book book, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}