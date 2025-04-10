using ED.Result;
using MediatR;

namespace SmartBuildingServer.Application.Features.Rooms.DeleteRoom;
public sealed record DeleteRoomCommand(Guid Id) : IRequest<Result<string>>;