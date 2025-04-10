using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.GetAllRoomByAppUserId;
public sealed record GetAllRoomByAppUserIdQuery(Guid AppUserId) : IRequest<Result<List<Room>>>;
