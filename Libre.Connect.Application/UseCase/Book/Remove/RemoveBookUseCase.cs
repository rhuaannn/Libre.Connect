using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories;

namespace Libre.Connect.Application.UseCase.Book.Remove;

public class RemoveBookUseCase
{
    private readonly IWriteOnlyBookRepository _writeOnlyBookRepository;
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;
    
    public RemoveBookUseCase(IWriteOnlyBookRepository writeOnlyBookRepository, IReadOnlyBookRepository readOnlyBookRepository)
    {
        _writeOnlyBookRepository = writeOnlyBookRepository;
        _readOnlyBookRepository = readOnlyBookRepository;
    }
    public async Task<RemoveBookUseCaseResponse> Handle(Guid id)
    {
        var book = await _readOnlyBookRepository.GetByIdAsync(id);
        if (book == null)
        {
            throw new DomainException("Book not found.");
        }
        
        await _writeOnlyBookRepository.DeleteAsync(id);
        return new RemoveBookUseCaseResponse();
    }
}