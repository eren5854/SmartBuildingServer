using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.UpdateSensorData;
internal sealed class UpdateSensorDataCommandHandler(
    ISensorDataRepository sensorDataRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateSensorDataCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateSensorDataCommand request, CancellationToken cancellationToken)
    {
        SensorData sensorData = await sensorDataRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (sensorData is null)
        {
            return Result<string>.Failure("Sensor data not found");
        }

        mapper.Map(request, sensorData);
        sensorData.UpdatedAt = DateTime.Now;
        sensorDataRepository.Update(sensorData);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Sensor data updated successfully");
    }
}
