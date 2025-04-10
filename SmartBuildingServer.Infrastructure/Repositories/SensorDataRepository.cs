using ED.GenericRepository;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;
using SmartBuildingServer.Infrastructure.Context;

namespace SmartBuildingServer.Infrastructure.Repositories;
public sealed class SensorDataRepository : Repository<SensorData, ApplicationDbContext>, ISensorDataRepository
{
    public SensorDataRepository(ApplicationDbContext context) : base(context)
    {
    }
}