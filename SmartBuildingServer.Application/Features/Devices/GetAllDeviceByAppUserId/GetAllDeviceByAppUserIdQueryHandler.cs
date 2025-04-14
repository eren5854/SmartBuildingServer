using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetAllDeviceByAppUserId;
internal sealed class GetAllDeviceByAppUserIdQueryHandler(
    IDeviceRepository deviceRepository) : IRequestHandler<GetAllDeviceByAppUserIdQuery, Result<List<Device>>>
{
    public async Task<Result<List<Device>>> Handle(GetAllDeviceByAppUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Device> devices = await deviceRepository
            .GetAll()
            .Where(w => w.AppUserId == request.AppUserId)
            .OrderBy(o => o.CreatedAt)
            .ToListAsync(cancellationToken);

        return Result<List<Device>>.Succeed(devices);
    }
}
