using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Rooms.UpdateRoom;
public sealed record UpdateRoomCommand(
    Guid Id,
    string RoomName,
    string? RoomDescription) : IRequest<Result<string>>;
