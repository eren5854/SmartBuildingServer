using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Rooms.CreateRoom;
public sealed record CreateRoomCommand(
    string RoomName,
    string? RoomDescription,
    Guid AppUserId) : IRequest<Result<string>>;
