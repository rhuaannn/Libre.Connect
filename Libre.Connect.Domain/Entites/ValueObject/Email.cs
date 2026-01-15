namespace Libre.Connect.Domain.Entites.ValueObject;

public record Email
{
    public string Value { get; private set; }

    private Email(string value) => Value = value;

    public static Email Create(string value)
    {
        if (value.Length > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(value));   
        }
        if(!value.Contains('@'))
        {
            throw new ArgumentException("E-mail precisa ser valido.");
        }
        return new Email(value);
    }

    public static implicit operator Email(string value) => Create(value);
    public static implicit operator string(Email email) => email.Value;
    public override string ToString() => Value;
}