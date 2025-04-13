using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDeviceSecretKey;
public sealed record UpdateDeviceSecretKeyCommand(Guid Id) : IRequest<Result<string>>;