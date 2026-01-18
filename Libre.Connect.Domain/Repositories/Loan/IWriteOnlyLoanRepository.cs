namespace Libre.Connect.Domain.Repositories.Loan;

public interface IWriteOnlyLoanRepository
{
    public Task AddAsync(Domain.Entites.Loan loan);
    public Task UpdateAsync(Domain.Entites.Loan loan, CancellationToken cancellationToken = default);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}