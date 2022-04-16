using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertisementApp.DataAccess.Migrations
{
    public partial class editedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "AppUsers",
                newName: "Surname");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 16, 12, 40, 6, 334, DateTimeKind.Local).AddTicks(1181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 29, 20, 55, 13, 884, DateTimeKind.Local).AddTicks(5073));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AppUsers",
                newName: "Lastname");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Advertisements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 29, 20, 55, 13, 884, DateTimeKind.Local).AddTicks(5073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 16, 12, 40, 6, 334, DateTimeKind.Local).AddTicks(1181));
        }
    }
}
