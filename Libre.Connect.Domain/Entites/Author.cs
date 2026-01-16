using Libre.Connect.Domain.Entites.Abstraction;
using Libre.Connect.Domain.Entites.ValueObject;

namespace Libre.Connect.Domain.Entites;

public sealed class Author : BaseEntity
{
    public Name Name { get; private set; }
    public ICollection<Book> Books { get; private set; } = new List<Book>();

    private Author()
    {
    }
    private Author(Name name)
    {
        Name = name;
    }
    public static Author Create(string name)
    {
        return new Author(name);
    }
}