using BankApp.Application.Features.IndividualCreditApplications.Commands.Create;
using BankApp.Application.Features.IndividualCreditApplications.Queries.GetById;
using BankApp.Application.Features.IndividualCreditApplications.Queries.GetList;
using BankApp.Core.Requests;
using BankApp.Core.Application.Responses;
using BankApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCreditApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateIndividualCreditApplicationCommand createIndividualCreditApplicationCommand)
    {
        CreatedIndividualCreditApplicationResponse response = await Mediator.Send(createIndividualCreditApplicationCommand);
        return Created(uri: "", response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdIndividualCreditApplicationQuery getByIdIndividualCreditApplicationQuery)
    {
        GetByIdIndividualCreditApplicationResponse response = await Mediator.Send(getByIdIndividualCreditApplicationQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] Guid? individualCustomerId, [FromQuery] CreditApplicationStatus? status)
    {
        GetListIndividualCreditApplicationQuery getListIndividualCreditApplicationQuery = new() { PageRequest = pageRequest, Status = status };
        GetListResponse<GetListIndividualCreditApplicationListItemDto> response = await Mediator.Send(getListIndividualCreditApplicationQuery);
        return Ok(response);
    }
} 