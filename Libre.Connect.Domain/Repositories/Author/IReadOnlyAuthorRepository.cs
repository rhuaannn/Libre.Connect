namespace Libre.Connect.Domain.Repositories.Author;

public interface IReadOnlyAuthorRepository
{
    Task GetByIdAsync(Guid id);
    Task<IEnumerable<Entites.Author>> GetAllAsync(CancellationToken cancellationToken = default);
    
}