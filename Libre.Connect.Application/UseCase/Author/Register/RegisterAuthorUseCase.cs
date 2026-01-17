 using Libre.Connect.Domain.Repositories.Author;
 
namespace Libre.Connect.Application.UseCase.Author;

public class RegisterAuthorUseCase
{
    private readonly IWriteOnlyAuthorRepository _writeOnlyAuthorRepository;
    private readonly IReadOnlyAuthorRepository _readOnlyAuthorRepository;

    public RegisterAuthorUseCase(IWriteOnlyAuthorRepository writeOnlyAuthorRepository, IReadOnlyAuthorRepository readOnlyAuthorRepository, IReadOnlyAuthorRepository readOnlyAuthorRepository1)
    {
        _writeOnlyAuthorRepository = writeOnlyAuthorRepository;
        _readOnlyAuthorRepository = readOnlyAuthorRepository;
    }

    public async Task<RegisterAuthorUseCaseResponse> Handle(RegisterAuthorUseCaseInput request, CancellationToken cancellationToken = default)
    {
        var author = Domain.Entites.Author.Create(request.Name);
        await _writeOnlyAuthorRepository.AddAsync(author);
 
        return new RegisterAuthorUseCaseResponse
        {
            Id = author.Id,
            Name = author.Name.Value
        };
    }
}