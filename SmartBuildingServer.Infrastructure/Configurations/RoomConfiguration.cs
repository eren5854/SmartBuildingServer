using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBuildingServer.Domain.Rooms;

namespace SmartBuildingServer.Infrastructure.Configurations;
public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder
            .Property(p => p.RoomName)
            .IsRequired()
            .HasColumnType("varchar(250)")
            .HasMaxLength(250);

        builder
            .Property(p => p.RoomDescription)
            .IsRequired()
            .HasColumnType("varchar(1000)")
            .HasMaxLength(1000);

        builder.HasQueryFilter(filter => !filter.IsDeleted);
    }
}
