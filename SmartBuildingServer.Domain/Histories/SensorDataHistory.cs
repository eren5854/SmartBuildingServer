using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Sensors;
using System.Text.Json.Serialization;

namespace SmartBuildingServer.Domain.Logs;
public sealed class SensorDataHistory : Entity
{
    public Guid SensorDataId { get; set; }
    [JsonIgnore]
    public SensorData SensorData { get; set; } = default!;

    public double? Value { get; set; }
    public string? Value2 { get; set; }
}
