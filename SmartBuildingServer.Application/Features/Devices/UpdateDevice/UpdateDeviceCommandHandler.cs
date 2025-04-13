using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDevice;
internal sealed class UpdateDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateDeviceCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var isDeviceExists = await deviceRepository.GetByExpressionAsync(g => g.DeviceName == request.DeviceName, cancellationToken);
        if (isDeviceExists is not null)
        {
            return Result<string>.Failure("Cihaz adı zaten mevcut!!");
        }

        Device device = await deviceRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (device is null)
        {
            return Result<string>.Failure("Cihaz bulunamadı");
        }

        mapper.Map(request, device);
        device.UpdatedAt = DateTime.Now;
        device.UpdatedBy = "Admin";

        deviceRepository.Update(device);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Cihaz güncellemesi başarılı");
    }
}
