using ED.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetAllDeviceByRoomId;
internal sealed class GetAllDeviceByRoomIdQueryHandler(
    IDeviceRepository deviceRepository) : IRequestHandler<GetAllDeviceByRoomIdQuery, Result<List<Device>>>
{
    public async Task<Result<List<Device>>> Handle(GetAllDeviceByRoomIdQuery request, CancellationToken cancellationToken)
    {
        List<Device> devices = await deviceRepository
            .GetAll()
            .Where(w => w.RoomId == request.RoomId)
            .OrderBy(o => o.CreatedAt)
            .ToListAsync(cancellationToken);

        return Result<List<Device>>.Succeed(devices);
    }
}
