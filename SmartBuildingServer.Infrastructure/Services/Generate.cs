using SmartBuildingServer.Application.Services;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Sensors;
using System.Security.Cryptography;

namespace SmartBuildingServer.Infrastructure.Services;
internal class Generate : IGenerate
{
    public string GenerateDeviceSerialNo(Device device)
    {
        DateTime date = DateTime.UtcNow;
        string formattedDate = date.ToString("ddMMyy");

        var type = device.DeviceType.Name switch
        {
            "Esp32" => "ESP32",
            "Esp01" => "ESP01",
            "Nodemcu" => "NOD01",
            "RaspberryPi" => "RPI01",
            "Arduino" => "ARD01",
            _ => "OTH01",
        };

        Random random = new();
        int randomNumber = random.Next(100, 999);

        return $"SN{type}{formattedDate}{randomNumber}";
    }

    public string GenerateSecretKey()
    {
        using (var hmac = new HMACSHA256())
        {
            var key = Convert.ToBase64String(hmac.Key);
            return key.Replace("+", "").Replace("/", "").Replace("=", "");
        }
    }

    
}
