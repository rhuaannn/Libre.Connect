using Libre.Connect.Domain.Entites.Abstraction;
using Libre.Connect.Domain.Entites.ValueObject;

namespace Libre.Connect.Domain.Entites;

public sealed class Member: BaseEntity
{
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    
    private Member(string name, string email) => (Name, Email) = (name, email);
    
    private Member() { }
    
    public static Member Create(string name, string email)
    {
        return new Member(name, email);
    }
    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }
}