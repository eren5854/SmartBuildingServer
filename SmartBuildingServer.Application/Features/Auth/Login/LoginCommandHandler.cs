using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Application.Services;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Features.Auth.Login;
internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        string emailOrUsername = request.EmailOrUserName;
        AppUser? appUser = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Email == emailOrUsername ||
                                    p.UserName == emailOrUsername, cancellationToken);
        if (appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found");
        }

        SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, true);
        if (signInResult.IsLockedOut)
        {
            TimeSpan? timeSpan = appUser.LockoutEnd - DateTime.UtcNow;
            if (timeSpan is not null)
            {
                return Result<LoginCommandResponse>.Failure($"Password entered incorrectly 3 times! Wait {Math.Ceiling(timeSpan.Value.TotalSeconds)} seconds.");
            }
            else
            {
                return Result<LoginCommandResponse>.Failure("Wait 3 minutes");
            }
        }

        if (signInResult.IsNotAllowed)
        {
            return Result<LoginCommandResponse>.Failure("E-mail address is not confirmed");
        }

        if (!signInResult.Succeeded)
        {
            return Result<LoginCommandResponse>.Failure("Password is incorrect");
        }

        var loginResponse = await jwtProvider.CreateToken(appUser);

        return loginResponse;
    }
}
