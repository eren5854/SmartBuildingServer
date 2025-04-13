using FluentValidation;

namespace SmartBuildingServer.Application.Features.Devices.UpdateDevice;
public sealed class UpdateDeviceCommandValidator : AbstractValidator<UpdateDeviceCommand>
{
    public UpdateDeviceCommandValidator()
    {
        RuleFor(r => r.DeviceName)
            .NotEmpty()
            .WithMessage("Cihaz ismi boş olamaz")
            .MaximumLength(300)
            .WithMessage("Cihaz ismi 300 karakterden büyük olamaz.");

        RuleFor(r => r.DeviceDescription)
            .NotEmpty()
            .WithMessage("Cihaz açıklaması boş olamaz")
            .MaximumLength(1500)
            .WithMessage("Cihaz açıklaması 1500 karakterden büyük olamaz.");
    }
}
