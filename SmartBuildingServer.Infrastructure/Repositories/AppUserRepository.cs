using ED.GenericRepository;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Users;
using SmartBuildingServer.Infrastructure.Context;

namespace SmartBuildingServer.Infrastructure.Repositories;
public sealed class AppUserRepository : Repository<AppUser, ApplicationDbContext>, IAppUserRepository
{
    public AppUserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
