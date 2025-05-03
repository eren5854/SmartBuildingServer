using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetAllDevice;
internal sealed class GetAllDeviceQueryHandler(
    IDeviceRepository deviceRepository) : IRequestHandler<GetAllDeviceQuery, Result<List<Device>>>
{
    public async Task<Result<List<Device>>> Handle(GetAllDeviceQuery request, CancellationToken cancellationToken)
    {
        List<Device> devices = await deviceRepository.GetAll().Include(i => i.SensorDatas!.OrderBy(o => o.PinNumber)).OrderBy(o => o.CreatedAt).ToListAsync(cancellationToken);
        return Result<List<Device>>.Succeed(devices);
    }
}
