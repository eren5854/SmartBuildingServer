using FluentValidation;

namespace SmartBuildingServer.Application.Features.Auth.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty().WithMessage("İsim alanı boş olamaz!")
            .MinimumLength(3).WithMessage("İsim alanı en az 3 karakter olmalıdır!")
            .MaximumLength(100).WithMessage("İsim alanı en fazla 100 karakter olmalıdır!");
        RuleFor(r => r.LastName)
            .NotEmpty().WithMessage("Soyisim alanı boş olamaz!")
            .MinimumLength(3).WithMessage("Soyisim alanı en az 3 karakter olmalıdır!")
            .MaximumLength(300).WithMessage("Soyisim alanı en fazla 300 karakter olmalıdır!");
        RuleFor(r => r.UserName)
            .NotEmpty().WithMessage("Kullanıcı adı alanı boş olamaz!")
            .MinimumLength(3).WithMessage("Kullanıcı adı alanı en az 3 karakter olmalıdır!")
            .MaximumLength(100).WithMessage("Kullanıcı adı alanı en fazla 100 karakter olmalıdır!");
        RuleFor(r => r.Email)
            .NotEmpty().WithMessage("E-posta alanı boş olamaz!")
            .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı!")
            .MaximumLength(175).WithMessage("E-posta alanı en fazla 175 karakter olmalıdır!");
        RuleFor(r => r.Password)
            .NotEmpty().WithMessage("Şifre alanı boş olamaz!")
            .MinimumLength(6).WithMessage("Şifre alanı en az 6 karakter olmalıdır!")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.");
    }
}
