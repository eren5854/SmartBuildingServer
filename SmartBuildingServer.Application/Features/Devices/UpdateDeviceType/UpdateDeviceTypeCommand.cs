using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Enums;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDeviceType;
public sealed record UpdateDeviceTypeCommand(
    Guid Id,
    DeviceTypeSmartEnum DeviceType): IRequest<Result<string>>;
