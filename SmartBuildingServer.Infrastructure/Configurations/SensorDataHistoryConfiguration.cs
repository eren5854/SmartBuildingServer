using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBuildingServer.Domain.Logs;

namespace SmartBuildingServer.Infrastructure.Configurations;
public sealed class SensorDataHistoryConfiguration : IEntityTypeConfiguration<SensorDataHistory>
{
    public void Configure(EntityTypeBuilder<SensorDataHistory> builder)
    {
        builder.ToTable("SensorDataHistories");

        builder.HasOne(p => p.SensorData)
            .WithMany(p => p.SensorDataHistories)
            .HasForeignKey(p => p.SensorDataId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
