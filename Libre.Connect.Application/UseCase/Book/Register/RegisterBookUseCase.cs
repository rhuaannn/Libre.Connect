using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Repositories;

namespace Libre.Connect.Application.UseCase.CreateBook;

public class RegisterBookUseCase
{
    private readonly IWriteOnlyBookRepository _writeOnlyBookRepository;
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;

    public RegisterBookUseCase(IWriteOnlyBookRepository writeOnlyBookRepository, IReadOnlyBookRepository readOnlyBookRepository)
    {
        _writeOnlyBookRepository = writeOnlyBookRepository;
        _readOnlyBookRepository = readOnlyBookRepository;
    }
    public async Task<RegisterBookUseCaseResponse> Handle(RegisterBookUseCaseInput request,
        CancellationToken cancellationToken = default)
    {
        var book = Book.Create(request.Name, request.Publisher, request.DataLancamento, request.AuthorId);
        await _writeOnlyBookRepository.AddAsync(book);

        return new RegisterBookUseCaseResponse
        {
            Name = book.Name.Value,
            Id = book.Id,
            AuthorId = book.AuthorId
        };
    }
}