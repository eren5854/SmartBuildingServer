using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Infrastructure.Configurations;
public sealed class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
{
    public void Configure(EntityTypeBuilder<SensorData> builder)
    {
        builder
            .Property(p => p.DataName)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder
            .Property(p => p.PinNumber)
            .HasColumnType("int")
            .HasMaxLength(100);

        builder
            .Property(p => p.SensorType)
            .HasConversion(p => p.Value,
                           v => SensorTypeSmartEnum
                           .FromValue(v));

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
