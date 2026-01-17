using FluentValidation;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.Member;

public class RegisterMemberUseCaseValidator : AbstractValidator<RegisterMemberUseCaseInput>
{
    public RegisterMemberUseCaseValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceMessage.NameRequired);
        RuleFor(x => x.Email).NotEmpty().WithMessage(ResourceMessage.EmailRequired);
    }
}