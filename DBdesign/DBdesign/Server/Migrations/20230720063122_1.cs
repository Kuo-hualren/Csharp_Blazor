using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBdesign.Server.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punchs1_Employees_PunchId",
                table: "Punchs1");

            migrationBuilder.DropForeignKey(
                name: "FK_Punchs2_Employees_PunchId",
                table: "Punchs2");

            migrationBuilder.DropIndex(
                name: "IX_Punchs2_PunchId",
                table: "Punchs2");

            migrationBuilder.DropIndex(
                name: "IX_Punchs1_PunchId",
                table: "Punchs1");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Punchs2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Punchs1",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Punchs1",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeesId", "PunchIn", "PunchOut" },
                values: new object[] { null, new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4843), new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Punchs1",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmployeesId", "PunchIn", "PunchOut" },
                values: new object[] { null, new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4855), new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "Punchs2",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeesId", "PunchIn", "PunchOut" },
                values: new object[] { null, new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4872), new DateTime(2023, 7, 20, 14, 31, 22, 91, DateTimeKind.Local).AddTicks(4872) });

            migrationBuilder.CreateIndex(
                name: "IX_Punchs2_EmployeesId",
                table: "Punchs2",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Punchs1_EmployeesId",
                table: "Punchs1",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Punchs1_Employees_EmployeesId",
                table: "Punchs1",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Punchs2_Employees_EmployeesId",
                table: "Punchs2",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Punchs1_Employees_EmployeesId",
                table: "Punchs1");

            migrationBuilder.DropForeignKey(
                name: "FK_Punchs2_Employees_EmployeesId",
                table: "Punchs2");

            migrationBuilder.DropIndex(
                name: "IX_Punchs2_EmployeesId",
                table: "Punchs2");

            migrationBuilder.DropIndex(
                name: "IX_Punchs1_EmployeesId",
                table: "Punchs1");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Punchs2");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Punchs1");

            migrationBuilder.UpdateData(
                table: "Punchs1",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PunchIn", "PunchOut" },
                values: new object[] { new DateTime(2023, 7, 19, 17, 13, 59, 495, DateTimeKind.Local).AddTicks(2714), new DateTime(2023, 7, 19, 17, 13, 59, 495, DateTimeKind.Local).AddTicks(2723) });

            migrationBuilder.UpdateData(
                table: "Punchs1",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PunchIn", "PunchOut" },
                values: new object[] { new DateTime(2023, 7, 19, 17, 13, 59, 495, DateTimeKind.Local).AddTicks(2724), new DateTime(2023, 7, 19, 17, 13, 59, 495, DateTimeKind.Local).AddTicks(2725) });

            migrationBuilder.UpdateData(
                table: "Punchs2",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PunchIn", "PunchOut" },
                values: new object[] { new DateTime(2023, 7, 19, 17, 13, 59, 495, DateTimeKind.Local).AddTicks(3189), new DateTime(2023, 7, 19, 17, 13, 59, 495, DateTimeKind.Local).AddTicks(3190) });

            migrationBuilder.CreateIndex(
                name: "IX_Punchs2_PunchId",
                table: "Punchs2",
                column: "PunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Punchs1_PunchId",
                table: "Punchs1",
                column: "PunchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Punchs1_Employees_PunchId",
                table: "Punchs1",
                column: "PunchId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Punchs2_Employees_PunchId",
                table: "Punchs2",
                column: "PunchId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
