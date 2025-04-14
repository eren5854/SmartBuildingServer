using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.DeleteSensorData;
internal sealed class DeleteSensorDataCommandHandler(
    ISensorDataRepository sensorDataRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteSensorDataCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteSensorDataCommand request, CancellationToken cancellationToken)
    {
        SensorData sensorData = await sensorDataRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (sensorData is null)
        {
            return Result<string>.Failure("Sensor bulunamadı!");
        }
        
        sensorDataRepository.Delete(sensorData);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Sensor silindi!");
    }
}
