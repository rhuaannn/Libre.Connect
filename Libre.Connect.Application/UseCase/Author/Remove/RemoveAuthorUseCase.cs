using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories.Author;

namespace Libre.Connect.Application.UseCase.Author.Remove;

public class RemoveAuthorUseCase
{
    private readonly IWriteOnlyAuthorRepository _writeOnlyAuthorRepository;
    private readonly IReadOnlyAuthorRepository _readOnlyAuthorRepository;

    public RemoveAuthorUseCase(IWriteOnlyAuthorRepository writeOnlyAuthorRepository, IReadOnlyAuthorRepository readOnlyAuthorRepository)
    {
        _writeOnlyAuthorRepository = writeOnlyAuthorRepository;
        _readOnlyAuthorRepository = readOnlyAuthorRepository;
    }

    public async Task Handle(Guid id, CancellationToken cancellationToken = default)
    {
        var author = await _readOnlyAuthorRepository.ExistsAsync(id, cancellationToken);
        if (!author)
        {
            throw new ExceptionNotFound("Author not found.");
        }
        
        await _writeOnlyAuthorRepository.DeleteAsync(id, cancellationToken);
        
    }
}