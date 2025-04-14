﻿using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.GetDevice;
internal sealed class GetDeviceCommandHandler(
    IDeviceRepository deviceRepository) : IRequestHandler<GetDeviceCommand, Result<Device>>
{
    public async Task<Result<Device>> Handle(GetDeviceCommand request, CancellationToken cancellationToken)
    {
        Device device = await deviceRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (device is null)
        {
            return Result<Device>.Failure("Cihaz bulunamadı");
        }

        return Result<Device>.Succeed(device);
    }
}
