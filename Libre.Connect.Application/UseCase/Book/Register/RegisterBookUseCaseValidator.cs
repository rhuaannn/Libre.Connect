using FluentValidation;

namespace Libre.Connect.Application.UseCase.CreateBook;

public class RegisterBookUseCaseValidator : AbstractValidator<RegisterBookUseCaseInput>
{
    public RegisterBookUseCaseValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nome Obrigatório!");
        RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Id obrigatório!");
        RuleFor(x => x.Publisher).NotEmpty().WithMessage("Editorar obrigatória!");
    }
}