using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBuildingServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Device");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "Device",
                type: "varchar(300)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "DeviceDescription",
                table: "Device",
                type: "varchar(1500)",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceDescription",
                table: "Device");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "Device",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Device",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
