using Libre.Connect.Domain.Repositories;

namespace Libre.Connect.Application.UseCase.Book.GetAll;

public class GetBookUseCase
{
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;

    public GetBookUseCase(IReadOnlyBookRepository readOnlyBookRepository)
    {
        _readOnlyBookRepository = readOnlyBookRepository;
    }

    public async Task<IEnumerable<GetBookUseCaseResponse>> Handler(CancellationToken cancellationToken)
    {
        var books = await _readOnlyBookRepository.GetAllAsync(cancellationToken);
        var response = books.Select(book =>
            new GetBookUseCaseResponse()
            {
                Id = book.Id,
                Name = book.Name,
                Publisher = book.Publisher,
                DataLancamento = book.DataLancamento,
                AuthorId = book.AuthorId
            });
        return response;
    }
}