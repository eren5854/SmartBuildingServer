using ED.GenericRepository;
using SmartBuildingServer.Domain.Logs;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Infrastructure.Context;

namespace SmartBuildingServer.Infrastructure.Repositories;
public sealed class SensorDataHistoryRepository : Repository<SensorDataHistory, ApplicationDbContext>, ISensorDataHistoryRepository
{
    public SensorDataHistoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
