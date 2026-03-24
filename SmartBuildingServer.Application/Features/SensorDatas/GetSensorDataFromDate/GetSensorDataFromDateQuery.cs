using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Logs;
using SmartBuildingServer.Domain.Repositories;

namespace SmartBuildingServer.Application.Features.SensorDatas.GetSensorDataFromDate;
public sealed record GetSensorDataFromDateQuery(
    Guid SensorDataId,
    DateTime StartDate,
    DateTime EndDate) : IRequest<Result<List<SensorDataHistory>>>;

internal sealed class GetSensorDataFromDateQueryHandler(
    ISensorDataRepository sensorDataRepository) : IRequestHandler<GetSensorDataFromDateQuery, Result<List<SensorDataHistory>>>
{
    public async Task<Result<List<SensorDataHistory>>> Handle(GetSensorDataFromDateQuery request, CancellationToken cancellationToken)
    {
        var sensorData = sensorDataRepository.Where(w => w.Id == request.SensorDataId).Include(w => w.SensorDataHistories).FirstOrDefault();
        if (sensorData is null)
            return Result<List<SensorDataHistory>>.Failure("Sensor data not found");
        var histories = sensorData.SensorDataHistories?
            .Where(h => h.CreatedAt >= request.StartDate && h.CreatedAt <= request.EndDate)
            .OrderByDescending(h => h.CreatedAt)
            .ToList();
        return Result<List<SensorDataHistory>>.Succeed(histories);
    }
}