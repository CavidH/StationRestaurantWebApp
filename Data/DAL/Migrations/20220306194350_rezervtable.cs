using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DAL.Migrations
{
    public partial class rezervtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<int>(nullable: false),
                    MaxPersonCount = table.Column<int>(nullable: false),
                    IsReserved = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Additionals = table.Column<string>(type: "TEXT", nullable: false),
                    ReservDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TableID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableID",
                        column: x => x.TableID,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableID",
                table: "Reservations",
                column: "TableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
