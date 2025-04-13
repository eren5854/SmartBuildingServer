using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Enums;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDevice;
public sealed record UpdateDeviceCommand(
    Guid Id,
    string DeviceName,
    string? DeviceDescription,
    DeviceTypeSmartEnum DeviceType,
    Guid RoomId) :IRequest<Result<string>>;