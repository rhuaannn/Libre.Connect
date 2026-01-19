using Libre.Connect.Application.UseCase.Loan;
using Libre.Connect.Application.UseCase.Loan.GetAll;
using Libre.Connect.Model;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class LoanController : BaseController
{
    private readonly RegisterLoanUseCase _registerLoanUseCase;
    private readonly GetAllLoanUseCase  _getAllLoanUseCase;

    public LoanController(RegisterLoanUseCase registerLoanUseCase, GetAllLoanUseCase getAllLoanUseCase)
    {
        _registerLoanUseCase = registerLoanUseCase;
        _getAllLoanUseCase = getAllLoanUseCase;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RegisterLoanUseCaseResponse>), StatusCodes.Status201Created)]  
    public async Task<IActionResult> Register([FromBody] RegisterLoanUseCaseInput input)
    {
        var response = await _registerLoanUseCase.Handle(input);
        return Created(string.Empty, response);    
    }
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<GetAllLoanUseCaseResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _getAllLoanUseCase.Handle(cancellationToken);
        return Ok(ApiResponse<IEnumerable<GetAllLoanUseCaseResponse>>.SuccessResponse(response));
    }
    
}