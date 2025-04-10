using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Features.Auth.ChangePassword;
internal sealed class ChangePasswordCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<ChangePasswordCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.AppUserId.ToString());
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        if(request.CurrentPassword == request.NewPassword)
        {
            return Result<string>.Failure("Yeni şifre mevcut şifreden farklı olmalı");
        }

        IdentityResult result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Hata!! Şifre değiştirme başarısız!!");
        }

        return Result<string>.Succeed("Şifre değiştirme başarılı.");
    }
}
