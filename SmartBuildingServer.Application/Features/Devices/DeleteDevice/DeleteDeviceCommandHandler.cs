using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.DeleteDevice;
internal sealed class DeleteDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDeviceCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        Device device = await deviceRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (device is null)
        {
            return Result<string>.Failure("Cihaz bulunamadı");
        }

        device.IsDeleted = true;
        deviceRepository.Update(device);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Cihaz silindi");
    }
}
