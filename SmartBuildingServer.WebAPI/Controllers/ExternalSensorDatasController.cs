using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBuildingServer.Application.Features.ExternalSensorDatas;
using SmartBuildingServer.WebAPI.Abstractions;

namespace SmartBuildingServer.WebAPI.Controllers;

public sealed class ExternalSensorDatasController : ApiController
{
    public ExternalSensorDatasController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> AddSensorData([FromForm] AddSensorDataCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return StatusCode(result.StatusCode, result);
    }
}
