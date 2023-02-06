using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoDabiServiceAPI.Migrations
{
    public partial class Files6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarName",
                table: "Files",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarName",
                table: "Files");
        }
    }
}
