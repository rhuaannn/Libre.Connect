using Libre.Connect.Application.UseCase.Member;
using Libre.Connect.Application.UseCase.Member.GetAll;
using Libre.Connect.Application.UseCase.Member.Update;
using Libre.Connect.Domain.Entites;
using Libre.Connect.Domain.Repositories.Member;
using Libre.Connect.Model;
using Microsoft.AspNetCore.Mvc;

namespace Libre.Connect.Controller;

public class MemberController : BaseController
{
    private readonly RegisterMemberUseCase _registerMemberUseCase;
    private readonly GetAllMemberUseCase _getAllMemberUseCase;
    private readonly UpdateMemberUseCase _updateMemberUseCase;

    public MemberController(RegisterMemberUseCase registerMemberUseCase, GetAllMemberUseCase getAllMemberUseCase, UpdateMemberUseCase updateMemberUseCase)
    {
        _registerMemberUseCase = registerMemberUseCase; 
        _getAllMemberUseCase = getAllMemberUseCase;
        _updateMemberUseCase = updateMemberUseCase;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<RegisterMemberUseCaseResponse>), StatusCodes.Status201Created)]
    
    public async Task<IActionResult> Register([FromBody] RegisterMemberUseCaseInput input)
    {
        var response = await _registerMemberUseCase.Handle(input);
        return Created(string.Empty, response);    
    }

    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<GetAllMemberUseCaseResponse>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiResponse<GetAllMemberUseCaseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<GetAllMemberUseCaseResponse>), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _getAllMemberUseCase.Handle(cancellationToken);
        return Ok(ApiResponse<IEnumerable<GetAllMemberUseCaseResponse>>.SuccessResponse(response));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateMemberUseCaseInput input)
    {
        await _updateMemberUseCase.Handle(id, input);
        return NoContent();
    }

}