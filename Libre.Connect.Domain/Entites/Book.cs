using Libre.Connect.Domain.Entites.Abstraction;
using Libre.Connect.Domain.Entites.ValueObject;

namespace Libre.Connect.Domain.Entites;

public sealed class Book : BaseEntity
{
    public Name Name { get; private set; }
    public string Publisher { get; private set; }
    public DateTime DataLancamento { get; private set; }
    public bool IsAvailable { get; private set; } = true;    
    public Guid AuthorId { get; private set; } 
    public Author? Author { get; private set; }
    public ICollection<Loan> Loans { get; private set; } = new List<Loan>();
    
    private Book()
    {
    }
    private Book(string name, string publisher, DateTime dataLancamento, Guid authorId)
    {
        Name = name;
        Publisher = publisher;
        AuthorId = authorId;
        DataLancamento = dataLancamento;
    }
    public static Book Create(string name, string publisher, DateTime dataLancamento, Guid authorId)
    {
        return new Book(name, publisher, dataLancamento, authorId);
    }
    public void MarkAsBarrowed() => IsAvailable = false;

    public void MarkAsReturn()
    {
        IsAvailable = true;
        UpdatedAt = DateTime.UtcNow;
    }
}