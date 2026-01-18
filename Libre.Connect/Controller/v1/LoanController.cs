using Libre.Connect.Application.UseCase.Loan;
using Libre.Connect.Model;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class LoanController : BaseController
{
    private readonly RegisterLoanUseCase _registerLoanUseCase;

    public LoanController(RegisterLoanUseCase registerLoanUseCase)
    {
        _registerLoanUseCase = registerLoanUseCase;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RegisterLoanUseCaseResponse>), StatusCodes.Status201Created)]  
    public async Task<IActionResult> Register([FromBody] RegisterLoanUseCaseInput input)
    {
        var response = await _registerLoanUseCase.Handle(input);
        return Created(string.Empty, response);    
    }
    
}