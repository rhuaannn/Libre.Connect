namespace Libre.Connect.Application.UseCase.CreateBook;

public class RegisterBookUseCaseInput
{
    public string Name { get; set; }
    public string Publisher { get; set; }
    public DateTime DataLancamento { get; set; } = DateTime.UtcNow;
    public Guid AuthorId { get; set; }
}