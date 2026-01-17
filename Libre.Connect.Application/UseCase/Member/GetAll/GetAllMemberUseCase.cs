using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories.Member;

namespace Libre.Connect.Application.UseCase.Member.GetAll;

public class GetAllMemberUseCase
{
    private readonly IReadOnlyMemberRepository _readOnlyMemberRepository;
    
    public GetAllMemberUseCase(IReadOnlyMemberRepository readOnlyMemberRepository)
    {
        _readOnlyMemberRepository = readOnlyMemberRepository;
    }
    
    public async Task<IEnumerable<GetAllMemberUseCaseResponse>> Handle(CancellationToken cancellationToken)
    {
        var members = await _readOnlyMemberRepository.GetAllAsync();
        if (members.Count() == 0)
        {
            throw new ExceptionNotFound("Members not found.");
        }
        var response = members.Select(member =>
                new GetAllMemberUseCaseResponse()
                {
                    Id = member.Id,
                    Name = member.Name,
                    Email = member.Email
                });
        return response;
    }
}