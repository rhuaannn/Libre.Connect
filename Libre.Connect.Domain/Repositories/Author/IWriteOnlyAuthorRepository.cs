namespace Libre.Connect.Domain.Repositories.Author;

public interface IWriteOnlyAuthorRepository
{
    public Task AddAsync(Entites.Author author);
    public Task UpdateAsync(Entites.Author author, CancellationToken cancellationToken = default);
    public Task DeleteAsync(Entites.Author author, CancellationToken cancellationToken = default);
    
}