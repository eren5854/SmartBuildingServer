using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Sensors;
using SmartBuildingServer.Domain.Users;
using System.Text.Json.Serialization;

namespace SmartBuildingServer.Domain.Rooms;
public sealed class Room : Entity
{
    public string RoomName { get; set; } = string.Empty;
    public string? RoomDescription { get; set; }

    public List<Device>? Devices { get; set; }

    [JsonIgnore]
    public Guid? AppUserId { get; set; }
    [JsonIgnore]
    public AppUser? AppUser { get; set; }
}
