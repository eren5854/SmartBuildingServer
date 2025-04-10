using AutoMapper;
using ED.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Application.Services;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Application.Features.Auth.Register;
internal sealed class RegisterCommandHandler(
    UserManager<AppUser> userManager,
    IMapper mapper,
    IGenerate generate) : IRequestHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool isEmailExists = await userManager.Users.AnyAsync(a => a.Email == request.Email, cancellationToken);
        if (isEmailExists)
        {
            return Result<string>.Failure("Email already exists");
        }

        bool isUserNameExists = await userManager.Users.AnyAsync(a => a.UserName == request.UserName, cancellationToken);
        if (isUserNameExists)
        {
            return Result<string>.Failure("Username already exists");
        }

        AppUser user = mapper.Map<AppUser>(request);
        user.CreatedBy = request.UserName;
        user.CreatedDate = DateTime.Now;
        user.SecretToken = generate.GenerateSecretKey();
        user.EmailConfirmed = true;

        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.FirstOrDefault()?.Description ?? "Unknown error");
        }

        return Result<string>.Succeed("User created successful");
    }
}
