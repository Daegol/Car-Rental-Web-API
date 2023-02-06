using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoDabiServiceAPI.Migrations
{
    public partial class Files3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Cars_CarId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CarId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Files");
        }
    }
}
