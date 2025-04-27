using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Rooms;
using SmartBuildingServer.Domain.Users;
using System.Text.Json.Serialization;

namespace SmartBuildingServer.Domain.Sensors;
public sealed class Device : Entity
{
    public string DeviceName { get; set; } = string.Empty;
    public string? DeviceDescription { get; set; }
    public string SerialNo { get; set; } = string.Empty;
    public bool? Status { get; set; }

    public string? SecretKey { get; set; }

    public DeviceTypeSmartEnum DeviceType { get; set; } = DeviceTypeSmartEnum.Other;

    //[JsonIgnore]
    //public Guid? AppUserId { get; set; }
    //[JsonIgnore]
    //public AppUser? AppUser { get; set; }

    //public object? RoomInfo => new
    //{
    //    RoomId = RoomId,
    //    RoomName = Room?.RoomName,
    //    RoomDescription = Room?.RoomDescription,
    //};

    [JsonIgnore]
    public Guid? RoomId { get; set; }
    [JsonIgnore]
    public Room? Room { get; set; }

    public List<SensorData>? SensorDatas { get; set; }

}
