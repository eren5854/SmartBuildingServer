using Microsoft.AspNetCore.Identity;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.WebAPI.Middlewares;

public static class ExtensionMiddleware
{
    public static void CreateAdmin(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if(!userManager.Users.Any(p => p.Email == "info@erendelibas.com"))
            {
                AppUser user = new()
                {
                    FirstName = "Eren",
                    LastName = "Delibaş",
                    UserName = "admin",
                    Email = "info@erendelibas.com",
                    SecretToken = Generate.GenerateSecretKey(),
                    Role = UserRoleSmartEnum.Admin,
                    EmailConfirmed = true,
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                };
                userManager.CreateAsync(user, "Password123*").Wait();
            }
        }
    }
}
