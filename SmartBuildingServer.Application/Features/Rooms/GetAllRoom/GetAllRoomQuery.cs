using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.GetAllRoom;
public sealed record GetAllRoomQuery() : IRequest<Result<List<Room>>>;
