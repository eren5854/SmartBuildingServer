using Ardalis.SmartEnum;

namespace SmartBuildingServer.Domain.Enums;
public sealed class UserRoleSmartEnum : SmartEnum<UserRoleSmartEnum>
{
    public static readonly UserRoleSmartEnum SuperAdmin = new UserRoleSmartEnum("SuperAdmin", 0);
    public static readonly UserRoleSmartEnum Admin = new UserRoleSmartEnum("Admin", 1);
    public static readonly UserRoleSmartEnum User = new UserRoleSmartEnum("User", 2);
    public UserRoleSmartEnum(string name, int value) : base(name, value)
    {
    }
}
