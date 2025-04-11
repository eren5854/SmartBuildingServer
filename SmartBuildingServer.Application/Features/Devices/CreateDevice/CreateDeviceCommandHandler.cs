using AutoMapper;
using ED.GenericRepository;
using ED.Result;
using MediatR;
using SmartBuildingServer.Application.Services;
using SmartBuildingServer.Domain.Repositories;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Application.Features.Devices.CreateDevice;
internal sealed class CreateDeviceCommandHandler(
    IDeviceRepository deviceRepository,
    IUnitOfWork unitOfWork,
    IGenerate generate,
    IMapper mapper) : IRequestHandler<CreateDeviceCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        var isDeviceExists = await deviceRepository.GetByExpressionAsync(g => g.DeviceName == request.DeviceName, cancellationToken);
        if (isDeviceExists is not null)
        {
            return Result<string>.Failure("Cihaz adı zaten mevcut!!");
        }

        Device device = mapper.Map<Device>(request);
        device.CreatedAt = DateTime.Now;
        device.CreatedBy = "Admin";
        device.SecretKey = generate.GenerateSecretKey();
        device.SerialNo = generate.GenerateDeviceSerialNo(device);

        await deviceRepository.AddAsync(device, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Cihaz kaydı başarılı");
    }
}
