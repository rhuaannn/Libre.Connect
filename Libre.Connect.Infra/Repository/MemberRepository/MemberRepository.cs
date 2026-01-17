using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Repositories.Member;
using Microsoft.EntityFrameworkCore;

namespace Libre.Connect.Infra.Repository.MemberRepository;

public class MemberRepository : IReadOnlyMemberRepository, IWriteOnlyMemberRepository
{
    private readonly LibreConnectDbContext _dbContext;

    public MemberRepository(LibreConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Member>> GetAllAsync()
    {
        return await _dbContext.Members.ToListAsync();
    }

    public async Task<Member?> GetByIdAsync(Guid id)
    {
       return await _dbContext.Members.FindAsync(id);
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var member = await GetByIdAsync(id);
        return member != null;
    }

    public async Task AddAsync(Member member)
    {
        await _dbContext.AddAsync(member);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Member member, CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var member = await GetByIdAsync(id);
        _dbContext.Remove(member);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}