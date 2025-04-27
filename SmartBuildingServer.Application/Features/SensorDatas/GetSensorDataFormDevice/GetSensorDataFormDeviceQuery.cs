using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.GetSensorDataFormDevice;
public sealed record GetSensorDataFormDeviceQuery(
    string SecretKey) : IRequest<Result<List<SensorData>>>;