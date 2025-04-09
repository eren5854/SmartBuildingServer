using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBuildingServer.Application.Features.Auth.Login;
using SmartBuildingServer.WebAPI.Abstractions;

namespace SmartBuildingServer.WebAPI.Controllers;

public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
