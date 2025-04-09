using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Infrastructure.Configurations;
public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
            .Property(p => p.FirstName)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder
            .Property(p => p.LastName)
            .IsRequired()
            .HasColumnType("varchar(300)")
            .HasMaxLength(200);

        builder
            .Property(p => p.UserName)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250)
            .IsRequired();

        builder
            .Property(p => p.Email)
            .HasColumnType("varchar(175)")
            .HasMaxLength(175)
            .IsRequired();

        builder
            .Property(p => p.Role)
            .HasConversion(p => p.Value,
                           v => UserRoleSmartEnum
                           .FromValue(v));

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
