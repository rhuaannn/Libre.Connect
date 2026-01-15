using Libre.Connect.Application.UseCase.CreateBook;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class BookController : BaseController
{
    private readonly RegisterBookUseCase _registerBookUseCase;
    
    public BookController(RegisterBookUseCase registerBookUseCase, CancellationToken cancellationToken)
    {
        _registerBookUseCase = registerBookUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterBookUseCaseInput input,
        CancellationToken cancellationToken)
    {
        var response = await _registerBookUseCase.Handle(input, cancellationToken);
        return Created(string.Empty, response);    
    }
    
}