namespace Libre.Connect.Domain.Repositories.Member;

public interface IWriteOnlyMemberRepository
{
    public Task AddAsync(Domain.Entites.Member member);
    public Task UpdateAsync(Domain.Entites.Member member, CancellationToken cancellationToken = default);
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    
}