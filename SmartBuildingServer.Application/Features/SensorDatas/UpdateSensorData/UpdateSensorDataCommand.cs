using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Enums;

namespace SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorData;
public sealed record UpdateSensorDataCommand(
    Guid Id,
    SensorTypeSmartEnum SensorType,
    string DataName,
    int PinNumber) : IRequest<Result<string>>;
