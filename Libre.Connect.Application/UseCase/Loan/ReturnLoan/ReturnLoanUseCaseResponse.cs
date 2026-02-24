namespace Libre.Connect.Application.UseCase.Loan.ReturnLoan;

public class ReturnLoanUseCaseResponse
{
    public Guid BookId { get; set; }
    public DateTime ActualReturnDate { get; set; }
    public Decimal Fees { get; set; }
}