using Libre.Connect.Application.UseCase.CreateBook;
using Libre.Connect.Model;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class BookController : BaseController
{
    private readonly RegisterBookUseCase _registerBookUseCase;
    
    public BookController(RegisterBookUseCase registerBookUseCase)
    {
        _registerBookUseCase = registerBookUseCase;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RegisterBookUseCaseResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterBookUseCaseInput input,
        CancellationToken cancellationToken)
    {
        var response = await _registerBookUseCase.Handle(input, cancellationToken);
        return Created(string.Empty, response);    
    }
    
}