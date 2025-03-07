using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private ISender? _mediatorSender;

    protected ISender Mediator => _mediatorSender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
} 