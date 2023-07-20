using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployRec.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Punchs1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunchIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PunchOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punchs1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punchs1_Employees_EmploId",
                        column: x => x.EmploId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Punchs2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PunchId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunchIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PunchOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punchs2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punchs2_Employees_EmploId",
                        column: x => x.EmploId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Phone", "Position", "PunchId" },
                values: new object[,]
                {
                    { 1, "sss@gmail.com", "Ben", "0966666666", "engineer", 1 },
                    { 2, "sssss@gmail.com", "Alan", "0977777777", "engineer", 2 }
                });

            migrationBuilder.InsertData(
                table: "Punchs1",
                columns: new[] { "Id", "EmploId", "Hours", "Name", "PunchId", "PunchIn", "PunchOut", "Time" },
                values: new object[,]
                {
                    { 1, null, "", "Ben", 1, new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4746), new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4758), "2023/07/19" },
                    { 2, null, "", "Ben", 1, new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4759), new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4760), "2023/07/19" }
                });

            migrationBuilder.InsertData(
                table: "Punchs2",
                columns: new[] { "Id", "EmploId", "Hours", "Name", "PunchId", "PunchIn", "PunchOut", "Time" },
                values: new object[] { 1, null, "", "Alan", 2, new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4776), new DateTime(2023, 7, 20, 16, 1, 2, 975, DateTimeKind.Local).AddTicks(4776), "2023/07/19" });

            migrationBuilder.CreateIndex(
                name: "IX_Punchs1_EmploId",
                table: "Punchs1",
                column: "EmploId");

            migrationBuilder.CreateIndex(
                name: "IX_Punchs2_EmploId",
                table: "Punchs2",
                column: "EmploId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punchs1");

            migrationBuilder.DropTable(
                name: "Punchs2");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
