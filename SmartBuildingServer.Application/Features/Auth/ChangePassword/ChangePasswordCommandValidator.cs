using FluentValidation;

namespace SmartBuildingServer.Application.Features.Auth.ChangePassword;
public sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(r => r.NewPassword)
            .NotEmpty()
            .WithMessage("New password is required.")
            .MinimumLength(8)
            .WithMessage("New password must be at least 8 characters long.")
            .Matches("[A-Z]")
            .WithMessage("New password must contain at least one uppercase letter.")
            .Matches("[a-z]")
            .WithMessage("New password must contain at least one lowercase letter.")
            .Matches("[0-9]")
            .WithMessage("New password must contain at least one number.");
            //.Matches("[^a-zA-Z0-9]")
            //.WithMessage("New password must contain at least one special character.");
    }
}
