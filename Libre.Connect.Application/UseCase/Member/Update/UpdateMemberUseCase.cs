using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories.Member;

namespace Libre.Connect.Application.UseCase.Member.Update;

public class UpdateMemberUseCase
{
    private readonly IWriteOnlyMemberRepository _writeOnlyMemberRepository;
    private readonly IReadOnlyMemberRepository _readOnlyMemberRepository;

    public UpdateMemberUseCase(IWriteOnlyMemberRepository writeOnlyMemberRepository, IReadOnlyMemberRepository readOnlyMemberRepository)
    {
        _writeOnlyMemberRepository = writeOnlyMemberRepository;
        _readOnlyMemberRepository = readOnlyMemberRepository;
    }

    public async Task Handle(Guid id, UpdateMemberUseCaseInput request)
    {
        var member = await _readOnlyMemberRepository.GetByIdAsync(id);
        if (member == null)
        {
            throw new ExceptionNotFound("Member not found.");
        }
        member.Update(request.Name, request.Email);
        await _writeOnlyMemberRepository.UpdateAsync(member);
     }
}