using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories;
using Libre.Connect.Domain.Repositories.Loan;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.Loan.ReturnLoan;

public class ReturnLoanUseCase
{
    private readonly IWriteOnlyLoanRepository _writeOnlyLoanRepository;
    private readonly IReadOnlyLoanRepository _readOnlyLoanRepository;
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;

    public ReturnLoanUseCase(IWriteOnlyLoanRepository writeOnlyLoanRepository, IReadOnlyLoanRepository readOnlyLoanRepository, IReadOnlyBookRepository readOnlyBookRepository)
    {
        _readOnlyLoanRepository = readOnlyLoanRepository;
        _writeOnlyLoanRepository = writeOnlyLoanRepository;
        _readOnlyBookRepository = readOnlyBookRepository;
    }

    public async Task<ReturnLoanUseCaseResponse> Handle(ReturnLoanUseCaseInput input)
    {
        var loan = await _readOnlyLoanRepository.GetByIdAsync(input.LoanId);
    
        if (loan == null)
        {
            throw new DomainException("Loan not found.");
        }
        var book = await _readOnlyBookRepository.GetByIdAsync(loan.BookId);
        if (book == null)
        {
            throw new DomainException("Book associated with this loan not found.");
        }

        var fess = 20m;

        loan.FinishLoan(fess); 

        await _writeOnlyLoanRepository.UpdateAsync(loan);
        
        return new ReturnLoanUseCaseResponse
        {
            BookId = loan.BookId,
            Fees = loan.Fees,
            ActualReturnDate = loan.ActualReturnDate.Value
        };
    }
}