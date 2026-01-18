using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories;
using Libre.Connect.Redis.Interface;

namespace Libre.Connect.Application.UseCase.Book.Remove;

public class RemoveBookUseCase
{
    private readonly IWriteOnlyBookRepository _writeOnlyBookRepository;
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;
    private readonly ICaching _cache;
    
    public RemoveBookUseCase(IWriteOnlyBookRepository writeOnlyBookRepository, 
        IReadOnlyBookRepository readOnlyBookRepository,
        ICaching cache
        )
    {
        _writeOnlyBookRepository = writeOnlyBookRepository;
        _readOnlyBookRepository = readOnlyBookRepository;
        _cache = cache;
    }
    public async Task<RemoveBookUseCaseResponse> Handle(Guid id)
    {
        var book = await _readOnlyBookRepository.GetByIdAsync(id);
        if (book == null)
        {
            throw new ExceptionNotFound("Book not found.");
        }
        
        await _writeOnlyBookRepository.DeleteAsync(id);
        await _cache.RemoveAsync("all_books_cache");
        return new RemoveBookUseCaseResponse();
    }
}