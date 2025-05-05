using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.SensorDatas.GetSensorData;
internal sealed class GetSensorDataQueryHandler(
    ISensorDataRepository sensorDataRepository) : IRequestHandler<GetSensorDataQuery, Result<SensorData>>
{
    public async Task<Result<SensorData>> Handle(GetSensorDataQuery request, CancellationToken cancellationToken)
    {
        SensorData? sensorData = await sensorDataRepository
            .Where(w => w.Id == request.Id)
            .Include(i => i.SensorDataHistories!.OrderByDescending(o => o.CreatedAt))
            .FirstOrDefaultAsync(cancellationToken);

        if (sensorData is null)
        {
            return Result<SensorData>.Failure("Sensor data not found");
        }

        return Result<SensorData>.Succeed(sensorData);
    }
}
