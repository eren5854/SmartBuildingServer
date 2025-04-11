using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Infrastructure.Configurations;
public sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder
            .Property(p => p.DeviceName)
            .IsRequired()
            .HasColumnType("varchar(300)")
            .HasMaxLength(250);

        builder
            .Property(p => p.DeviceDescription)
            .HasColumnType("varchar(1500)")
            .HasMaxLength(1000);

        builder
            .Property(p => p.DeviceType)
            .HasConversion(p => p.Value,
            v => DeviceTypeSmartEnum.FromValue(v));

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
