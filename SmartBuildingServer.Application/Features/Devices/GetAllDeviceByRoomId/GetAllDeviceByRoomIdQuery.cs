using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetAllDeviceByRoomId;
public sealed record GetAllDeviceByRoomIdQuery(Guid RoomId) : IRequest<Result<List<Device>>>;
