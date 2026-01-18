using FluentValidation;
using Libre.Connect.Message;

namespace Libre.Connect.Application.UseCase.Member.Update;

public class UpdateMemberUseCaseValidator : AbstractValidator<UpdateMemberUseCaseInput>
{
    public UpdateMemberUseCaseValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage(ResourceMessage.NameRequired);
        
        RuleFor(x => x.Email).NotEmpty()
            .EmailAddress()
            .WithMessage(ResourceMessage.EmailRequired);
    }
}