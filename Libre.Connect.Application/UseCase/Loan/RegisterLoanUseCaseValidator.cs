using FluentValidation;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.Loan;

public class RegisterLoanUseCaseValidator : AbstractValidator<RegisterLoanUseCaseInput>
{
    public RegisterLoanUseCaseValidator()
    {
        RuleFor(x => x.BookId).NotEmpty().WithMessage(ResourceMessage.BookRequired);
        RuleFor(x => x.MemberId).NotEmpty().WithMessage(ResourceMessage.MemberRequired);
    }
}