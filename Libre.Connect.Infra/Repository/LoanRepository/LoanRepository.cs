using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Repositories.Loan;
using Microsoft.EntityFrameworkCore;

namespace Libre.Connect.Infra.Repository.LoanRepository;

public class LoanRepository : IReadOnlyLoanRepository, IWriteOnlyLoanRepository
{
    private readonly LibreConnectDbContext _dbContext;

    public LoanRepository(LibreConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Loan?>> GetAllAsync()
    {
        return await _dbContext.Loans.ToListAsync();
    }

    public async Task<Loan?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Loans.FindAsync(id);
    }

    public async Task<bool> IsBookCurrentlyLoanedAsync(Guid bookId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Loans
            .AnyAsync(l => l.BookId == bookId && l.ActualReturnDate == null, cancellationToken);
    }

    public async Task AddAsync(Loan loan)
    {
        await _dbContext.AddAsync(loan);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Loan loan, CancellationToken cancellationToken = default)
    {
        _dbContext.Update(loan);
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}