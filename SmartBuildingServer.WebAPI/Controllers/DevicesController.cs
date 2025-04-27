using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBuildingServer.Application.Features.Devices.CreateDevice;
using SmartBuildingServer.Application.Features.Devices.DeleteDevice;
using SmartBuildingServer.Application.Features.Devices.GetAllDevice;
using SmartBuildingServer.Application.Features.Devices.GetAllDeviceByAppUserId;
using SmartBuildingServer.Application.Features.Devices.GetDevice;
using SmartBuildingServer.Application.Features.Devices.UpdateDevice;
using SmartBuildingServer.Application.Features.Devices.UpdateDeviceSecretKey;
using SmartBuildingServer.Application.Features.Devices.UpdateDeviceType;
using SmartBuildingServer.WebAPI.Abstractions;

namespace SmartBuildingServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class DevicesController : ApiController
{
    public DevicesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDeviceQuery(), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByAppUserId(Guid AppUserId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllDeviceByAppUserIdQuery(AppUserId), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetDeviceCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateType(UpdateDeviceTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateSecretKey(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateDeviceSecretKeyCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid Id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteDeviceCommand(Id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
