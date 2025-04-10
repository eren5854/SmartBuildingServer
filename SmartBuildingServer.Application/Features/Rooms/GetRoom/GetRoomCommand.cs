using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.GetRoom;
public sealed record GetRoomCommand(Guid Id) : IRequest<Result<Room>>;
