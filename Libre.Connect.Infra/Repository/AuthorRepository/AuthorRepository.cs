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
    public async Task GetByIdAsync(Guid id)
    {
        await _dbContext.FindAsync<Author>(id);
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

    public Task DeleteAsync(Author author, CancellationToken cancellationToken = default)
    {
        _dbContext.Authors.Remove(author);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
    
}