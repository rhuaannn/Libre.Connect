namespace Libre.Connect.Application.UseCase.Loan;

public class RegisterLoanUseCaseInput
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime DateLoan { get; set; } = DateTime.UtcNow;
}