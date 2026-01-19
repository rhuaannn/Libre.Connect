using Libre.Connect.Domain.Entites;

namespace Libre.Connect.Domain.Repositories.Loan;

public interface IReadOnlyLoanRepository
{
    public Task<IEnumerable<Domain.Entites.Loan>> GetAllAsync();
    public Task<Domain.Entites.Loan?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<bool> IsBookCurrentlyLoanedAsync(Guid id , CancellationToken cancellationToken = default);
}