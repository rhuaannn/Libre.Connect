using Libre.Connect.Application.UseCase.Book.GetAll;
using Libre.Connect.Application.UseCase.Book.Remove;
using Libre.Connect.Application.UseCase.CreateBook;
using Libre.Connect.Model;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class BookController : BaseController
{
    private readonly RegisterBookUseCase _registerBookUseCase;
    private readonly GetBookUseCase _getBookUseCase;
    private readonly RemoveBookUseCase _removeBookUseCase;
    
    public BookController(RegisterBookUseCase registerBookUseCase, GetBookUseCase getBookUseCase, RemoveBookUseCase removeBookUseCase)
    {
        _registerBookUseCase = registerBookUseCase;
        _getBookUseCase = getBookUseCase;
        _removeBookUseCase = removeBookUseCase;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RegisterBookUseCaseResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterBookUseCaseInput input,
        CancellationToken cancellationToken)
    {
        var response = await _registerBookUseCase.Handle(input, cancellationToken);
        return Created(string.Empty, ApiResponse<RegisterBookUseCaseResponse>.SuccessResponse(response));    
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<GetBookUseCaseResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _getBookUseCase.Handler(cancellationToken);
        return Ok(ApiResponse<IEnumerable<GetBookUseCaseResponse>>.SuccessResponse(response));
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ApiResponse<RemoveBookUseCaseResponse>), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Remove(Guid id, CancellationToken cancellationToken)
    {
        var response = await _removeBookUseCase.Handle(id);
        return NoContent();
    }
    
}