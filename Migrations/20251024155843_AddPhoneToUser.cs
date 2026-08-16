using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism_App.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Destinations_DestinationId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DestinationId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "NumberOfPeople * ChargePerPerson",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[NumberOfPeople] * [ChargePerPerson]",
                oldStored: null);

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1561361513-2d000a50f0dc?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1625731226721-b4d51ae70e20?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[NumberOfPeople] * [ChargePerPerson]",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "NumberOfPeople * ChargePerPerson");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1573843981267-be1999ff37cd?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1699630923504-9a24dbaab37c?w=800&h=600&fit=crop");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1562979314-bee7453e911c?w=800&h=600&fit=crop");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DestinationId1",
                table: "Bookings",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Destinations_DestinationId1",
                table: "Bookings",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId1",
                table: "Bookings",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
