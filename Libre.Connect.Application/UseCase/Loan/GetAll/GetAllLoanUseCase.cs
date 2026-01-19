using Libre.Connect.Domain.Repositories.Loan;

namespace Libre.Connect.Application.UseCase.Loan.GetAll;

public class GetAllLoanUseCase
{
    private readonly IReadOnlyLoanRepository _readOnlyLoanRepository;

    public GetAllLoanUseCase(IReadOnlyLoanRepository readOnlyLoanRepository)
    {
        _readOnlyLoanRepository = readOnlyLoanRepository;
    }

    public async Task<IEnumerable<GetAllLoanUseCaseResponse>> Handle(CancellationToken cancellationToken)
    {
        var loans = await _readOnlyLoanRepository.GetAllAsync();
        var response = loans.Select(loan =>
            new GetAllLoanUseCaseResponse()
            {
                Id = loan.Id,
                BookId = loan.BookId,
                MemberId= loan.MemberId,
                DateLoan = loan.DateLoan
                
            });
        return response;
    }
}