namespace Libre.Connect.Domain.Repositories.Member;

public interface IReadOnlyMemberRepository
{
    public Task<IEnumerable<Domain.Entites.Member>> GetAllAsync();
    public Task<Domain.Entites.Member?> GetByIdAsync(Guid id);
    public Task<bool> ExistsAsync(Guid id);
}
