using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Enums;

namespace SmartBuildingServer.Application.Features.Devices.CreateDevice;
public sealed record CreateDeviceCommand(
    string DeviceName,
    string? DeviceDescription,
    DeviceTypeSmartEnum DeviceType,
    Guid AppUserId,
    Guid RoomId) : IRequest<Result<string>>;
