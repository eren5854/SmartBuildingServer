using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.GetSensorDataFormDevice;
internal sealed class GetSensorDataFormDeviceQueryHandler(
    IDeviceRepository deviceRepository) : IRequestHandler<GetSensorDataFormDeviceQuery, Result<List<SensorData>>>
{
    public async Task<Result<List<SensorData>>> Handle(GetSensorDataFormDeviceQuery request, CancellationToken cancellationToken)
    {
        Device? device = await deviceRepository.Where(w => w.SecretKey == request.SecretKey)
            .Include(i => i.SensorDatas!.OrderBy(o => o.PinNumber))
            .FirstOrDefaultAsync(cancellationToken);

        if (device is null)
        {
            return Result<List<SensorData>>.Failure("Device not found");
        }

        if (device.SensorDatas is null)
        {
            return Result<List<SensorData>>.Failure("Sensor data not found");
        }

        return Result<List<SensorData>>.Succeed(device.SensorDatas);
    }
}
