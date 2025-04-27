using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.GetRoom;
internal sealed class GetRoomCommandHandler(
    IRoomRepository roomRepository) : IRequestHandler<GetRoomCommand, Result<Room>>
{
    public async Task<Result<Room>> Handle(GetRoomCommand request, CancellationToken cancellationToken)
    {
        Room? room = await roomRepository
            .Where(w => w.Id == request.Id)
            .Include(i => i.Devices!
                    .OrderBy(o => o.CreatedAt))
            .ThenInclude(t => t.SensorDatas!
                    .OrderBy(o => o.CreatedAt))
            .FirstOrDefaultAsync(cancellationToken);

        if (room is null)
        {
            return Result<Room>.Failure($"Room with id {request.Id} not found.");
        }

        return Result<Room>.Succeed(room);
    }
}
