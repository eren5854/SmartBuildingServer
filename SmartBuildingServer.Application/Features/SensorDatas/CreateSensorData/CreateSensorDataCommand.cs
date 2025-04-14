using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Enums;

namespace SmartBuildingServer.Application.Features.SensorDatas.CreateSensorData;
public sealed record CreateSensorDataCommand(
    SensorTypeSmartEnum SensorType,
    string DataName,
    int PinNumber,
    Guid DeviceId) : IRequest<Result<string>>;
