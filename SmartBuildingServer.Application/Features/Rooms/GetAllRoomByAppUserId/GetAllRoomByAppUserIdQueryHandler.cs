using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Application.Features.Rooms.GetAllRoomByAppUserId;
internal sealed class GetAllRoomByAppUserIdQueryHandler(
    IRoomRepository roomRepository) : IRequestHandler<GetAllRoomByAppUserIdQuery, Result<List<Room>>>
{
    public async Task<Result<List<Room>>> Handle(GetAllRoomByAppUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Room> rooms = await roomRepository.GetAll().Where(g => g.AppUserId == request.AppUserId).OrderBy(o => o.CreatedAt)
            .ToListAsync(cancellationToken);

        if (rooms is null || rooms.Count == 0)
        {
            return Result<List<Room>>.Failure("Hiç oda bulunamadı");
        }

        return Result<List<Room>>.Succeed(rooms);
    }
}
