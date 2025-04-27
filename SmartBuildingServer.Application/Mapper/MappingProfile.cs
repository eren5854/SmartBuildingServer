using AutoMapper;
using SmartBuildingServer.Application.Features.Auth.Register;
using SmartBuildingServer.Application.Features.Devices.CreateDevice;
using SmartBuildingServer.Application.Features.Devices.UpdateDevice;
using SmartBuildingServer.Application.Features.Rooms.CreateRoom;
using SmartBuildingServer.Application.Features.Rooms.UpdateRoom;
using SmartBuildingServer.Application.Features.SensorDatas.CreateSensorData;
using SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorData;
using SmartBuildingServer.Domain.Rooms;
using SmartBuildingServer.Domain.Sensors;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Mapper;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterCommand, AppUser>();

        CreateMap<CreateRoomCommand, Room>();
        CreateMap<UpdateRoomCommand, Room>();

        CreateMap<CreateDeviceCommand, Device>();
        CreateMap<UpdateDeviceCommand, Device>();

        CreateMap<CreateSensorDataCommand, SensorData>();
        CreateMap<UpdateSensorDataCommand, SensorData>();
    }
}
