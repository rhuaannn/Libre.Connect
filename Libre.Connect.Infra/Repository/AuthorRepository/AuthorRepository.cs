using System.Collections;
using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Repositories.Author;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Libre.Connect.Infra.Repository.AuthorRepository;

public class AuthorRepository : IReadOnlyAuthorRepository, IWriteOnlyAuthorRepository
{
    private readonly LibreConnectDbContext _dbContext;
    public AuthorRepository(LibreConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Authors.FindAsync(id);
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Authors.AnyAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Authors.ToListAsync(cancellationToken);
    }
    
    public async Task AddAsync(Author author)
    {
        await _dbContext.AddAsync(author);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Author author, CancellationToken cancellationToken = default)
    {
         _dbContext.Update(author);
         return _dbContext.SaveChangesAsync(cancellationToken);
        
    }

    public async Task DeleteAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        var author = await _dbContext.Authors.FindAsync(Id);
        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
}