using SmartBuildingServer.Domain.Entities;
using SmartBuildingServer.Domain.Enums;
using System.Text.Json.Serialization;

namespace SmartBuildingServer.Domain.Sensors;
public sealed class SensorData : Entity
{
    public SensorTypeSmartEnum SensorType = SensorTypeSmartEnum.Other;
    public string DataName { get; set; } = string.Empty;
    public int PinNumber { get; set; } = default!;
    public double? Value { get; set; }
    public string? Value2 { get; set; }

    [JsonIgnore]
    public Guid? DeviceId { get; set; }
    [JsonIgnore]
    public Device? Device { get; set; }
}
