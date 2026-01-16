using Libre.Connect.Application.UseCase.Author;
using Libre.Connect.Application.UseCase.Author.GetAll;
using Libre.Connect.Model;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class AuthorController : BaseController
{
    private readonly RegisterAuthorUseCase _registerAuthorUseCase;
    private readonly GetAuthorUseCase _getAuthorUseCase;

    public AuthorController(RegisterAuthorUseCase registerAuthorUseCase, GetAuthorUseCase getAuthorUseCase)
    {
        _registerAuthorUseCase = registerAuthorUseCase;
        _getAuthorUseCase = getAuthorUseCase;
        
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RegisterAuthorUseCaseResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RegisterAuthorUseCaseInput input, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var response = await _registerAuthorUseCase.Handle(input);
        return Created(string.Empty, response);    
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<GetAuthorUseCaseResoponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var useCaseResult = await _getAuthorUseCase.Handle(cancellationToken);
        var response = new ApiResponse<IEnumerable<GetAuthorUseCaseResoponse>>(useCaseResult);
        
        return Ok(response);
    }
}