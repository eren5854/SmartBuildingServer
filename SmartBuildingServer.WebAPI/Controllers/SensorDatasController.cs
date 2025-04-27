using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBuildingServer.Application.Features.SensorDatas.CreateSensorData;
using SmartBuildingServer.Application.Features.SensorDatas.DeleteSensorData;
using SmartBuildingServer.Application.Features.SensorDatas.GetSensorDataFormDevice;
using SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorData;
using SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorDataFromDevice;
using SmartBuildingServer.WebAPI.Abstractions;

namespace SmartBuildingServer.WebAPI.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class SensorDatasController : ApiController
{
    public SensorDatasController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSensorDataCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetFromDevice(string secretKey, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetSensorDataFormDeviceQuery(secretKey), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateSensorDataCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> UpdateFromDevice(UpdateSensorDataFromDeviceCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteSensorDataCommand(id), cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
