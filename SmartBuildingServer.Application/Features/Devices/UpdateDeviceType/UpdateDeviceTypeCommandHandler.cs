using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Application.Services;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDeviceType;
internal sealed class UpdateDeviceTypeCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork,
    IGenerate generate) : IRequestHandler<UpdateDeviceTypeCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDeviceTypeCommand request, CancellationToken cancellationToken)
    {
        Device device = await deviceRepository.GetByExpressionAsync(g => g.Id == request.Id, cancellationToken);
        if (device is null)
        {
            return Result<string>.Failure("Cihaz bulunamadı");
        }

        device.DeviceType = request.DeviceType;
        device.SerialNo = generate.GenerateDeviceSerialNo(device);

        var isSerialNoExist = await deviceRepository.AnyAsync(a => a.SerialNo == device.SerialNo && a.Id != device.Id, cancellationToken);
        if (isSerialNoExist)
        {
            while (!isSerialNoExist)
            {
                device.SerialNo = generate.GenerateDeviceSerialNo(device);
            }
        }

        deviceRepository.Update(device);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Cihaz tipi güncellendi");
    }
}
