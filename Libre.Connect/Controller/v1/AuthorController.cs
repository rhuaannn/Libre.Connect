using Libre.Connect.Application.UseCase.Author;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class AuthorController : BaseController
{
    private readonly RegisterAuthorUseCase _registerAuthorUseCase;

    public AuthorController(RegisterAuthorUseCase registerAuthorUseCase)
    {
        _registerAuthorUseCase = registerAuthorUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterAuthorUseCaseInput input, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var response = await _registerAuthorUseCase.Handle(input);
        return Created(string.Empty, response);    
    }
}