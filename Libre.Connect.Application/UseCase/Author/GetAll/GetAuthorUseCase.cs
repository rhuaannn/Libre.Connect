using Libre.Connect.Domain.Repositories.Author;

namespace Libre.Connect.Application.UseCase.Author.GetAll;

public class GetAuthorUseCase
{
    private readonly IReadOnlyAuthorRepository _readOnlyAuthorRepository;

    public GetAuthorUseCase(IReadOnlyAuthorRepository readOnlyAuthorRepository)
    {
        _readOnlyAuthorRepository = readOnlyAuthorRepository;
    }

    public async Task<IEnumerable<GetAuthorUseCaseResoponse>> Handle(CancellationToken cancellationToken)
    {
        var authors = await _readOnlyAuthorRepository.GetAllAsync(cancellationToken);

        var response = authors.Select(author =>
            new GetAuthorUseCaseResoponse
            {
                Id = author.Id,
                Name = author.Name
            });

        return response;
    }
}