using BankApp.Application.Features.CreditTypes.Commands.Create;
using BankApp.Application.Features.CreditTypes.Commands.Delete;
using BankApp.Application.Features.CreditTypes.Commands.Update;
using BankApp.Application.Features.CreditTypes.Queries.GetById;
using BankApp.Application.Features.CreditTypes.Queries.GetList;
using BankApp.Core.Application.Requests;
using BankApp.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditTypesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCreditTypeQuery getListCreditTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCreditTypeListItemDto> response = await Mediator.Send(getListCreditTypeQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCreditTypeQuery getByIdCreditTypeQuery = new() { Id = id };
        GetByIdCreditTypeResponse response = await Mediator.Send(getByIdCreditTypeQuery);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCreditTypeCommand createCreditTypeCommand)
    {
        CreatedCreditTypeResponse response = await Mediator.Send(createCreditTypeCommand);
        return Created("", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCreditTypeCommand updateCreditTypeCommand)
    {
        UpdatedCreditTypeResponse response = await Mediator.Send(updateCreditTypeCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCreditTypeCommand deleteCreditTypeCommand = new() { Id = id };
        DeletedCreditTypeResponse response = await Mediator.Send(deleteCreditTypeCommand);
        return Ok(response);
    }
} 