using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Sensors;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Domain.Rooms;
public sealed class Room : Entity
{
    public string RoomName { get; set; } = string.Empty;
    public string RoomDescription { get; set; } = string.Empty;

    public List<Sensor>? Sensors { get; set; }

    public Guid? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}
