using Libre.Connect.Domain.Entites.Abstraction;

namespace Libre.Connect.Domain.Entites;

public sealed class Loan : BaseEntity
{
    public DateTime DateLoan { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public DateTime? ActualReturnDate { get; private set; }
    public Decimal Fees { get; private set; }
    
    public Guid BookId { get; private set; }
    public Guid MemberId { get; private set; }
    
    public Book Book { get; private set; }
    public Member Member { get; private set; }
    
    private Loan()
    {
    }
    private Loan(Guid bookId, Guid memberId)
    {
        BookId = bookId;
        MemberId = memberId;
        DateLoan = DateTime.UtcNow;
        ExpectedReturnDate = DateTime.UtcNow.AddDays(7);
        Fees = 0;
    }

    public static Loan Create(Guid bookId, Guid memberId)
    {
        return new Loan
        {
            Id = Guid.NewGuid(),
            BookId = bookId,
            MemberId = memberId,
            DateLoan = DateTime.UtcNow,
            ExpectedReturnDate = DateTime.UtcNow.AddDays(7)
        };
    }

    public void UpdateExpectedReturnDate(DateTime expectedReturnDate)
    {
        ExpectedReturnDate = expectedReturnDate;
    }
    public void FinishLoan(decimal fees)
    {
        ActualReturnDate = DateTime.UtcNow;
        if (ActualReturnDate > ExpectedReturnDate)
        {
            var diasDeAtraso = (ActualReturnDate.Value.Date - ExpectedReturnDate.Date).Days;
            this.Fees = diasDeAtraso * fees;
            return;
        }
        this.Fees = 0;    
    }
}