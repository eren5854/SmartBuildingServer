using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Application.Services;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDeviceSecretKey;
internal sealed class UpdateDeviceSecretKeyCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork,
    IGenerate generate) : IRequestHandler<UpdateDeviceSecretKeyCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDeviceSecretKeyCommand request, CancellationToken cancellationToken)
    {
        Device device = await deviceRepository.GetByExpressionAsync(g => g.Id == request.Id);
        if (device is null)
        {
            return Result<string>.Failure("Cihaz bulunamadı");
        }

        device.SecretKey = generate.GenerateSecretKey();
        device.UpdatedAt = DateTime.UtcNow;
        device.UpdatedBy = "Admin";
        deviceRepository.Update(device);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Secret key güncellemesi başarılı");

    }
}
