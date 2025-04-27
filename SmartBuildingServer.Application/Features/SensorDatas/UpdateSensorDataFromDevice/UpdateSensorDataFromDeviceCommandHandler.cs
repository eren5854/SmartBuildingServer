using ED.GenericRepository;
using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorDataFromDevice;
internal sealed class UpdateSensorDataFromDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    ISensorDataRepository sensorDataRepository,
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

        foreach (var updateDto in request.SensorDatas)
        {
            // cihazın içindeki sensordata'lar arasında pin numarası eşleşen kaydı bul
            var sensorData = device.SensorDatas.FirstOrDefault(s => s.PinNumber == updateDto.PinNumber);

            if (sensorData is null)
                return Result<string>.Failure($"Sensor data with pin {updateDto.PinNumber} not found");

            // Değerleri güncelle
            sensorData.Value = updateDto.Value;
            sensorData.Value2 = updateDto.Value2;

            sensorDataRepository.Update(sensorData);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Sensor datas updated successfully");
    }
}
