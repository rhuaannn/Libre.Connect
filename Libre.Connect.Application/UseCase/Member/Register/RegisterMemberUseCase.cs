using Libre.Connect.Domain.Repositories.Member;

namespace Libre.Connect.Application.UseCase.Member;

public class RegisterMemberUseCase
{
    private readonly IWriteOnlyMemberRepository _writeOnlyMemberRepository;
    private readonly IReadOnlyMemberRepository _readOnlyMemberRepository;

    public RegisterMemberUseCase(IReadOnlyMemberRepository readOnlyMemberRepository, IWriteOnlyMemberRepository writeOnlyMemberRepository)
    {
        _readOnlyMemberRepository = readOnlyMemberRepository;
        _writeOnlyMemberRepository = writeOnlyMemberRepository;
    }

    public async Task<RegisterMemberUseCaseResponse> Handle(RegisterMemberUseCaseInput request, CancellationToken cancellationToken = default)
    {
        var member = Domain.Entites.Member.Create(request.Name, request.Email);
        await _writeOnlyMemberRepository.AddAsync(member);
 
        return new RegisterMemberUseCaseResponse
        {
            Id = member.Id,
            Name = member.Name.Value
        };
    }
}