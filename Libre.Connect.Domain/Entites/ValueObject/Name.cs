namespace Libre.Connect.Domain.Entites.ValueObject;

public record Name
{
    public string Value { get; private set; }

    private Name(string value)
    {
        Value = value;
    }

    public static Name Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < 3)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        if (value.Length > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }
        return new Name(value);
    }
    public static implicit operator Name(string value) => Create(value);
    public static implicit operator string(Name name) => name.Value;
    public override string ToString() => Value;
    
}