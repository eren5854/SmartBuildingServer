using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBuildingServer.Domain.Enums;
using SmartBuildingServer.Domain.Sensors;

namespace SmartBuildingServer.Infrastructure.Configurations;
public sealed class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder
            .Property(p => p.SensorName)
            .IsRequired()
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder
            .Property(p => p.Description)
            .HasColumnType("varchar(1000)")
            .HasMaxLength(1000);

        //builder
        //    .Property(p => p.SensorType)
        //    .HasConversion(p => p.Value,
        //    v => SensorTypeSmartEnum.FromValue(v));

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
