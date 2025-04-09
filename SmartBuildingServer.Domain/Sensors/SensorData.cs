using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Enums;
using System.Text.Json.Serialization;

namespace SmartBuildingServer.Domain.Sensors;
public sealed class SensorData : Entity
{
    public SensorTypeSmartEnum SensorType = SensorTypeSmartEnum.Other;
    public string? PinName { get; set; }
    public double? Value { get; set; }

    [JsonIgnore]
    public Guid? SensorId { get; set; }
    [JsonIgnore]
    public Sensor? Sensor { get; set; }
}
