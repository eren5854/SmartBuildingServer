using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.GetSensorData;
public sealed record GetSensorDataQuery(Guid Id) : IRequest<Result<SensorData>>;
