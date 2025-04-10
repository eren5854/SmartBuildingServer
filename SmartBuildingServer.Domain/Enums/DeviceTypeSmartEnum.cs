using Ardalis.SmartEnum;

namespace SmartBuildingServer.Domain.Enums;
public sealed class DeviceTypeSmartEnum : SmartEnum<DeviceTypeSmartEnum>
{
    public static readonly DeviceTypeSmartEnum Other = new DeviceTypeSmartEnum("Other", 0);
    public static readonly DeviceTypeSmartEnum Esp32 = new DeviceTypeSmartEnum("Esp32", 1);
    public static readonly DeviceTypeSmartEnum Esp01 = new DeviceTypeSmartEnum("Esp01", 2);
    public static readonly DeviceTypeSmartEnum Nodemcu = new DeviceTypeSmartEnum("Nodemcu", 3);
    public static readonly DeviceTypeSmartEnum RaspberryPi = new DeviceTypeSmartEnum("RaspberryPi", 4);
    public static readonly DeviceTypeSmartEnum Arduino = new DeviceTypeSmartEnum("Arduino", 5);

    public DeviceTypeSmartEnum(string name, int value) : base(name, value)
    {
    }
}
