using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetAllDeviceByAppUserId;
public sealed record GetAllDeviceByAppUserIdQuery(Guid AppUserId) : IRequest<Result<List<Device>>>;
