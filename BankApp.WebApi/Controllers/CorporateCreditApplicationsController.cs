using BankApp.Application.Features.CorporateCreditApplications.Commands.Create;
using BankApp.Application.Features.CorporateCreditApplications.Queries.GetById;
using BankApp.Application.Features.CorporateCreditApplications.Queries.GetList;
using BankApp.Core.Requests;
using BankApp.Core.Application.Responses;
using BankApp.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorporateCreditApplicationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCorporateCreditApplicationCommand createCorporateCreditApplicationCommand)
    {
        CreatedCorporateCreditApplicationResponse response = await Mediator.Send(createCorporateCreditApplicationCommand);
        return Created(uri: "", response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdCorporateCreditApplicationQuery getByIdCorporateCreditApplicationQuery)
    {
        GetByIdCorporateCreditApplicationResponse response = await Mediator.Send(getByIdCorporateCreditApplicationQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromQuery] Guid? corporateCustomerId, [FromQuery] CreditApplicationStatus? status)
    {
        GetListCorporateCreditApplicationQuery getListCorporateCreditApplicationQuery = new() { PageRequest = pageRequest, CorporateCustomerId = corporateCustomerId, Status = status };
        GetListResponse<GetListCorporateCreditApplicationListItemDto> response = await Mediator.Send(getListCorporateCreditApplicationQuery);
        return Ok(response);
    }
} 