using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Logs;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorDataFromDevice;
internal sealed class UpdateSensorDataFromDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    ISensorDataRepository sensorDataRepository,
    ISensorDataHistoryRepository sensorDataHistoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateSensorDataFromDeviceCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateSensorDataFromDeviceCommand request, CancellationToken cancellationToken)
    {
        Device? device = await deviceRepository
       .Where(w => w.SecretKey == request.SecretKey)
       .Include(i => i.SensorDatas)
       .FirstOrDefaultAsync(cancellationToken);

        if (device is null)
            return Result<string>.Failure("Device not found");

        if (device.SensorDatas is null)
            return Result<string>.Failure("Sensor data not found");

        foreach (var item in request.SensorDatas)
        {
            var sensorData = device.SensorDatas.FirstOrDefault(s => s.PinNumber == item.PinNumber);

            if (sensorData is null)
                return Result<string>.Failure($"Sensor data with pin {item.PinNumber} not found");

            sensorData.Value = item.Value;
            sensorData.Value2 = item.Value2;

            SensorDataHistory sensorDataHistory = new()
            {
                SensorDataId = sensorData.Id,
                Value = item.Value,
                Value2 = item.Value2,
            };

            await sensorDataHistoryRepository.AddAsync(sensorDataHistory, cancellationToken);
            sensorDataRepository.Update(sensorData);
        }

       

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Sensor datas updated successfully");
    }
}
