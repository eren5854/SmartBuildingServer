using ED.GenericRepository;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Rooms;
using SmartBuildingServer.Infrastructure.Context;

namespace SmartBuildingServer.Infrastructure.Repositories;
public sealed class RoomRepository : Repository<Room, ApplicationDbContext>, IRoomRepository
{
    public RoomRepository(ApplicationDbContext context) : base(context)
    {
    }
}
