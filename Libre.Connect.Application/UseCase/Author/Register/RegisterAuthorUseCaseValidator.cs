using FluentValidation;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.Author;

public class RegisterAuthorUseCaseValidator : AbstractValidator<RegisterAuthorUseCaseInput>
{
    public RegisterAuthorUseCaseValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceMessage.AuthorRequired);
    }
}