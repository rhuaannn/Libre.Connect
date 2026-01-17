namespace Libre.Connect.Application.UseCase.Book.GetAll;

public class GetBookUseCaseResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public DateTime DataLancamento { get; set; }
    public Guid AuthorId { get; set; }
    
}