using BankApp.Application.Features.CorporateCustomers.Commands.Create;
using BankApp.Application.Features.CorporateCustomers.Commands.Delete;
using BankApp.Application.Features.CorporateCustomers.Commands.Update;
using BankApp.Application.Features.CorporateCustomers.Queries.GetById;
using BankApp.Application.Features.CorporateCustomers.Queries.GetList;
using BankApp.Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCustomersController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCorporateCustomerQuery getListCorporateCustomerQuery = new() { PageRequest = pageRequest };
        var response = await Mediator.Send(getListCorporateCustomerQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCorporateCustomerQuery getByIdCorporateCustomerQuery = new() { Id = id };
        GetByIdCorporateCustomerResponse response = await Mediator.Send(getByIdCorporateCustomerQuery);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
    {
        CreatedCorporateCustomerResponse response = await Mediator.Send(createCorporateCustomerCommand);
        return Created("", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
    {
        UpdatedCorporateCustomerResponse response = await Mediator.Send(updateCorporateCustomerCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteCorporateCustomerCommand deleteCorporateCustomerCommand = new() { Id = id };
        DeletedCorporateCustomerResponse response = await Mediator.Send(deleteCorporateCustomerCommand);
        return Ok(response);
    }
} 