using FluentValidation;

namespace SmartBuildingServer.Application.Features.Rooms.CreateRoom;
public sealed class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
    public CreateRoomCommandValidator()
    {
        RuleFor(r => r.RoomName)
            .NotEmpty().WithMessage("Oda ismi boş olamaz.")
            .MaximumLength(250).WithMessage("Oda ismi en fazla 250 karakter olmalıdır.");

        RuleFor(r => r.RoomDescription)
            .MaximumLength(1000).WithMessage("Oda açıklaması en fazla 1000 karakter olmalıdır.");
    }
}
