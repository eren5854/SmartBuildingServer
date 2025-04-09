using SmartBuildingServer.Application.Features.Auth.Login;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Services;
public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}
