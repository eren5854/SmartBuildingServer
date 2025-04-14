using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Devices.DeleteDevice;
public sealed record class DeleteDeviceCommand(Guid Id) : IRequest<Result<string>>;
