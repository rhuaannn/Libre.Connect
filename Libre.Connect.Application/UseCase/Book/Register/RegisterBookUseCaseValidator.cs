using FluentValidation;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.CreateBook;

public class RegisterBookUseCaseValidator : AbstractValidator<RegisterBookUseCaseInput>
{
    public RegisterBookUseCaseValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceMessage.NameRequired);
        RuleFor(x => x.AuthorId).NotEmpty().WithMessage(ResourceMessage.AuthorRequired);
        RuleFor(x => x.Publisher).NotEmpty().WithMessage(ResourceMessage.PublisherRequired);
    }
}