using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.CreateSensorData;
internal sealed class CreateSensorDataCommandHandler(
    ISensorDataRepository sensorDataRepository,
    IDeviceRepository deviceRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateSensorDataCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateSensorDataCommand request, CancellationToken cancellationToken)
    {
        bool isDeviceExists = await deviceRepository.AnyAsync(x => x.Id == request.DeviceId, cancellationToken);
        if (!isDeviceExists)
        {
            return Result<string>.Failure("Cihaz bulunamadı");
        }

        SensorData sensorData = mapper.Map<SensorData>(request);
        sensorData.CreatedAt = DateTime.UtcNow;
        sensorData.CreatedBy = "Admin";
        sensorData.Value = 0;
        sensorData.Value2 = "";

        await sensorDataRepository.AddAsync(sensorData, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Sensor kaydı başarılı");
    }
}
