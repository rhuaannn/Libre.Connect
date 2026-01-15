namespace Libre.Connect.Application.UseCase.CreateBook;

public class RegisterBookUseCaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
}