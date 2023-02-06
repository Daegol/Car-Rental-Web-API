using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoDabiServiceAPI.Migrations
{
    public partial class Files4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Cars_CarId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CarId",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "Stream",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Stream",
                table: "Files",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CarId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CarId",
                table: "Files",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Cars_CarId",
                table: "Files",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
