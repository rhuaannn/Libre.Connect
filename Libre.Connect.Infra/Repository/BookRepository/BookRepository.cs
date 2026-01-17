using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Libre.Connect.Infra.Repository;

public class BookRepository : IWriteOnlyBookRepository, IReadOnlyBookRepository
{
    private readonly LibreConnectDbContext _dbContext;

    public BookRepository(LibreConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Book book)
    {
        await _dbContext.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Book book, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await _dbContext.Books.FindAsync(id);
        _dbContext.Remove(book);
        _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var book = await _dbContext.Books.FindAsync(id);
        return book;
    }

    public async Task<IEnumerable<Book>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Books.ToListAsync(cancellationToken);
    }
}