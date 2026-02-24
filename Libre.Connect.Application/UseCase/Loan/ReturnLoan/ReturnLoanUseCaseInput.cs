namespace Libre.Connect.Application.UseCase.Loan.ReturnLoan;

public class ReturnLoanUseCaseInput
{
    public Guid BookId { get; set; }
    public Guid LoanId { get; set; }
    public DateTime DateReturn { get; set; } = DateTime.UtcNow;
    
}