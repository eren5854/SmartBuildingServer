using MediatR;
using SmartBuildingServer.WebAPI.Abstractions;

namespace SmartBuildingServer.WebAPI.Controllers;

public sealed class SensorDatasController : ApiController
{
    public SensorDatasController(IMediator mediator) : base(mediator)
    {
    }
}
