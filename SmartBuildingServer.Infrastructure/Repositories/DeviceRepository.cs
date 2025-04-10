using ED.GenericRepository;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;
using SmartBuildingServer.Infrastructure.Context;

namespace SmartBuildingServer.Infrastructure.Repositories;
public sealed class DeviceRepository : Repository<Device, ApplicationDbContext>, IDeviceRepository
{
    public DeviceRepository(ApplicationDbContext context) : base(context)
    {
    }
}
