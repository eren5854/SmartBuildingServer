using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Rooms;
using SmartBuildingServer.Domain.Users;
using System.Text.Json.Serialization;

namespace SmartBuildingServer.Domain.Sensors;
public sealed class Sensor : Entity
{
    public string SensorName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string SerialNo { get; set; } = string.Empty;
    public string? Status { get; set; }

    public string? SecretKey { get; set; }

    //public SensorTypeSmartEnum SensorType { get; set; } = SensorTypeSmartEnum.Other;

    [JsonIgnore]
    public Guid? AppUserId { get; set; }
    [JsonIgnore]
    public AppUser? AppUser { get; set; }

    public object? RoomInfo => new
    {
        RoomId = RoomId,
        RoomName = Room?.RoomName,
        RoomDescription = Room?.RoomDescription,
    };

    [JsonIgnore]
    public Guid? RoomId { get; set; }
    [JsonIgnore]
    public Room? Room { get; set; }

    public List<SensorData>? SensorDatas { get; set; }

}
