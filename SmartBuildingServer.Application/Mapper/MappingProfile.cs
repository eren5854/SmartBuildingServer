using AutoMapper;
using SmartBuildingServer.Application.Features.Auth.Register;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Mapper;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>();
    }
}
