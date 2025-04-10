using AutoMapper;
using SmartBuildingServer.Application.Features.Auth.Register;
using SmartBuildingServer.Application.Features.Rooms.CreateRoom;
using SmartBuildingServer.Application.Features.Rooms.UpdateRoom;
using SmartBuildingServer.Domain.Rooms;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Mapper;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>();

        CreateMap<CreateRoomCommand, Room>();
        CreateMap<UpdateRoomCommand, Room>();
    }
}
