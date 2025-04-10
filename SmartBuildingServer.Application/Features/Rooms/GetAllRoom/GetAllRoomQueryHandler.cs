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
        List<Room> rooms = await roomRepository.GetAll().ToListAsync(cancellationToken);

    }
}
