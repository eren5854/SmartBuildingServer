using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetDevice;
public sealed record GetDeviceCommand(Guid Id) : IRequest<Result<Device>>;
