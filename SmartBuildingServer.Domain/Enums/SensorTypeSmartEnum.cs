using Ardalis.SmartEnum;

namespace SmartBuildingServer.Domain.Enums;
public sealed class SensorTypeSmartEnum : SmartEnum<SensorTypeSmartEnum>
{
    public static readonly SensorTypeSmartEnum Other = new SensorTypeSmartEnum("Other", 0);
    public static readonly SensorTypeSmartEnum Light = new SensorTypeSmartEnum("Light", 1);
    public static readonly SensorTypeSmartEnum Relay = new SensorTypeSmartEnum("Relay", 2);
    public static readonly SensorTypeSmartEnum Temperature = new SensorTypeSmartEnum("Temperature", 3);
    public static readonly SensorTypeSmartEnum LDR = new SensorTypeSmartEnum("LDR", 4);
    public static readonly SensorTypeSmartEnum Water = new SensorTypeSmartEnum("Water", 5);
    public static readonly SensorTypeSmartEnum Pressure = new SensorTypeSmartEnum("Pressure", 6);
    public static readonly SensorTypeSmartEnum Motion = new SensorTypeSmartEnum("Motion", 7);
    public static readonly SensorTypeSmartEnum Speed = new SensorTypeSmartEnum("Speed", 8);

    public SensorTypeSmartEnum(string name, int value) : base(name, value)
    {
    }
}
