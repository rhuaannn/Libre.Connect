using Libre.Connect.Domain.Exception;
using Libre.Connect.Domain.Repositories;
using Libre.Connect.Domain.Repositories.Loan;
using Libre.Connect.Domain.Repositories.Member;

namespace Libre.Connect.Application.UseCase.Loan;

public class RegisterLoanUseCase
{
    private readonly IWriteOnlyLoanRepository _writeOnlyLoanRepository;
    private readonly IReadOnlyBookRepository _readOnlyBookRepository;
    private readonly IReadOnlyMemberRepository _memberRepository;
    private readonly IReadOnlyLoanRepository _readOnlyLoanRepository;

    public RegisterLoanUseCase(IWriteOnlyLoanRepository writeOnlyLoanRepository,
        IReadOnlyBookRepository readOnlyBookRepository,
        IReadOnlyMemberRepository memberRepository,
        IReadOnlyLoanRepository readOnlyLoanRepository
        )
    {
        _writeOnlyLoanRepository = writeOnlyLoanRepository;
        _readOnlyBookRepository = readOnlyBookRepository;
        _memberRepository = memberRepository;
        _readOnlyLoanRepository = readOnlyLoanRepository;
    }

    public async Task<RegisterLoanUseCaseResponse> Handle(RegisterLoanUseCaseInput request)
    {
        var bookId = await _readOnlyBookRepository.GetByIdAsync(request.BookId);
        if (bookId == null)
        {
            throw new ExceptionNotFound("Book not found.");
        }
        var memberId = await _memberRepository.GetByIdAsync(request.MemberId);
        
        if (memberId == null)
        {
            throw new ExceptionNotFound("Member not found.");
        }
        var isBookAlreadyLoaned = await _readOnlyLoanRepository.IsBookCurrentlyLoanedAsync(request.BookId, CancellationToken.None);    
        if (isBookAlreadyLoaned)
        {
            throw new DomainException("Book already loaned.");
        }
        var loan = Domain.Entites.Loan.Create(request.BookId, request.MemberId);
        await _writeOnlyLoanRepository.AddAsync(loan);
        return new RegisterLoanUseCaseResponse
            {
                BookId = loan.BookId,
                MemberId = loan.MemberId,
                DateLoan = loan.DateLoan
            };
    }
}