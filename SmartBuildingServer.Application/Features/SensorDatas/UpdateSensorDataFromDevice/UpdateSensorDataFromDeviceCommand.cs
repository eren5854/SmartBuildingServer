using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.DTOs;

namespace SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorDataFromDevice;
public sealed record UpdateSensorDataFromDeviceCommand(
    string SecretKey,
    List<UpdateSensorDataDto> SensorDatas) : IRequest<Result<string>>;