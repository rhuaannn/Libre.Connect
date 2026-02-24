using FluentValidation;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.Loan.ReturnLoan;

public class ReturnLoanUseCaseValidator : AbstractValidator<ReturnLoanUseCaseInput>
{
    public ReturnLoanUseCaseValidator()
    {
        RuleFor(x => x.BookId).NotEmpty().WithMessage(ResourceMessage.BookRequired);
    }
    
}