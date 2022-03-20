using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DAL.Migrations
{
    public partial class timeinterval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Reservations",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservEndDate",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeIntervalId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeIntervals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<double>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeIntervals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeIntervalId",
                table: "Reservations",
                column: "TimeIntervalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TimeIntervals_TimeIntervalId",
                table: "Reservations",
                column: "TimeIntervalId",
                principalTable: "TimeIntervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TimeIntervals_TimeIntervalId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "TimeIntervals");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TimeIntervalId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservEndDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TimeIntervalId",
                table: "Reservations");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Reservations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
