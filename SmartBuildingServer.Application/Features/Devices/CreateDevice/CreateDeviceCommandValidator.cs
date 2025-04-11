using FluentValidation;

namespace SmartBuildingServer.Application.Features.Devices.CreateDevice;
public sealed class CreateDeviceCommandValidator : AbstractValidator<CreateDeviceCommand>
{
    public CreateDeviceCommandValidator()
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
