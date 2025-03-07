using BankApp.Application.Features.IndividualCustomers.Commands.Create;
using BankApp.Application.Features.IndividualCustomers.Commands.Delete;
using BankApp.Application.Features.IndividualCustomers.Commands.Update;
using BankApp.Application.Features.IndividualCustomers.Queries.GetById;
using BankApp.Application.Features.IndividualCustomers.Queries.GetList;
using BankApp.Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomerController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListIndividualCustomerQuery getListIndividualCustomerQuery = new() { PageRequest = pageRequest };
        var response = await Mediator.Send(getListIndividualCustomerQuery);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdIndividualCustomerQuery getByIdIndividualCustomerQuery = new() { Id = id };
        GetByIdIndividualCustomerResponse response = await Mediator.Send(getByIdIndividualCustomerQuery);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIndividualCustomerCommand createIndividualCustomerCommand)
    {
        CreatedIndividualCustomerResponse response = await Mediator.Send(createIndividualCustomerCommand);
        return Created("", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand updateIndividualCustomerCommand)
    {
        UpdatedIndividualCustomerResponse response = await Mediator.Send(updateIndividualCustomerCommand);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeleteIndividualCustomerCommand deleteIndividualCustomerCommand = new() { Id = id };
        DeletedIndividualCustomerResponse response = await Mediator.Send(deleteIndividualCustomerCommand);
        return Ok(response);
    }
} 