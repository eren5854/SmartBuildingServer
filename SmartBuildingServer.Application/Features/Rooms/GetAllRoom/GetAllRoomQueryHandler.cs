using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.GetAllRoom;
internal sealed class GetAllRoomQueryHandler(
    IRoomRepository roomRepository) : IRequestHandler<GetAllRoomQuery, Result<List<Room>>>
{
    public async Task<Result<List<Room>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        List<Room> rooms = await roomRepository
            .GetAll()
            .Include(i => i.Devices!
                    .OrderBy(o => o.CreatedAt))
            .ThenInclude(t => t.SensorDatas!
                    .OrderBy(o => o.CreatedAt))
            .OrderBy(o => o.CreatedAt)
            .ToListAsync(cancellationToken);
        if(rooms is null || rooms.Count == 0)
        {
            return Result<List<Room>>.Failure("Hiç oda bulunamadı");
        }

        return Result<List<Room>>.Succeed(rooms);
    }
}
