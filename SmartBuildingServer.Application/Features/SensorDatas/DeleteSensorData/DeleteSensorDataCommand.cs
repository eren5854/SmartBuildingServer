using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.SensorDatas.DeleteSensorData;
public sealed record DeleteSensorDataCommand(Guid Id) : IRequest<Result<string>>;
