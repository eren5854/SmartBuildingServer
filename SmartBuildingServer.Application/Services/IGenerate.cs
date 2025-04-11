using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Services;
public interface IGenerate
{
    string GenerateSecretKey();
    string GenerateDeviceSerialNo(Device device);
}
