using System.Text.Json;
using Libre.Connect.Domain.Repositories;
using Libre.Connect.Redis.Interface;

namespace Libre.Connect.Application.UseCase.Book.GetAll;

public class GetBookUseCase
{
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;
    private readonly ICaching _cache;
    private const string CacheKey = "all_books_cache";

    public GetBookUseCase(IReadOnlyBookRepository readOnlyBookRepository, ICaching cache)
    {
        _readOnlyBookRepository = readOnlyBookRepository;
        _cache = cache;
    }
    public async Task<IEnumerable<GetBookUseCaseResponse>> Handler(CancellationToken cancellationToken)
    {
        var cachedBooks = await _cache.GetAsync(CacheKey);
        if (!string.IsNullOrEmpty(cachedBooks))
        {
            return JsonSerializer.Deserialize<IEnumerable<GetBookUseCaseResponse>>(cachedBooks)!;
        }

        var books = await _readOnlyBookRepository.GetAllAsync(cancellationToken);

        var response = books.Select(book =>
            new GetBookUseCaseResponse()
            {
                Id = book.Id,
                Name = book.Name,
                Publisher = book.Publisher,
                DataLancamento = book.DataLancamento,
                AuthorId = book.AuthorId
            }).ToList();

        var serializedResponse = JsonSerializer.Serialize(response);
        await _cache.SetAsync(CacheKey, serializedResponse);

        return response;

    }
}