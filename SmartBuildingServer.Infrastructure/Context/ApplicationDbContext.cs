using ED.GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBuildingServer.Domain.Rooms;
using SmartBuildingServer.Domain.Sensors;
using SmartBuildingServer.Domain.Users;

namespace SmartBuildingServer.Infrastructure.Context;
public sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Room>()
            .HasOne(p => p.AppUser)
            .WithMany(p => p.Rooms)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Device>()
            .HasOne(p => p.Room)
            .WithMany(p => p.Devices)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.Entity<Device>()
        //    .HasOne(p => p.AppUser)
        //    .WithMany(p => p.Devices)
        //    .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<SensorData>()
            .HasOne(p => p.Device)
            .WithMany(p => p.SensorDatas)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
