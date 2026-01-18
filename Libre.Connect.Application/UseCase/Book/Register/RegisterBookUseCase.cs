using System.Text.Json;
using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories;
using Libre.Connect.Domain.Repositories.Author;
using Libre.Connect.Redis.Interface;

namespace Libre.Connect.Application.UseCase.CreateBook;
public class RegisterBookUseCase
{
    private readonly IWriteOnlyBookRepository _writeOnlyBookRepository;
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;
    private readonly IReadOnlyAuthorRepository _readOnlyAuthorRepository;
    private readonly ICaching _cache;

    public RegisterBookUseCase(IWriteOnlyBookRepository writeOnlyBookRepository, 
        IReadOnlyBookRepository readOnlyBookRepository, 
        IReadOnlyAuthorRepository readOnlyAuthorRepository,
        ICaching cache
        )
    {
        _writeOnlyBookRepository = writeOnlyBookRepository;
        _readOnlyBookRepository = readOnlyBookRepository;
        _readOnlyAuthorRepository = readOnlyAuthorRepository;
        _cache = cache;
    }
    public async Task<RegisterBookUseCaseResponse> Handle(RegisterBookUseCaseInput request,
        CancellationToken cancellationToken = default)
    {
        var authorExists = await _readOnlyAuthorRepository.ExistsAsync(request.AuthorId, cancellationToken);
        if (!authorExists)
        {
            throw new ExceptionNotFound("Author not found.");
        }

        var book = Domain.Entites.Book.Create(request.Name, request.Publisher, request.DataLancamento, request.AuthorId);
        await _writeOnlyBookRepository.AddAsync(book);

        var response = new RegisterBookUseCaseResponse
        {
            Name = book.Name.Value,
            Id = book.Id,
            AuthorId = book.AuthorId
        };
        await _cache.RemoveAsync("all_books_cache");
        return response;
    }
}