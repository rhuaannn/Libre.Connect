namespace Libre.Connect.Application.UseCase.Loan.GetAll;

public class GetAllLoanUseCaseResponse
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
    public DateTime DateLoan { get; set; }
}