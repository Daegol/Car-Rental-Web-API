using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoDabiServiceAPI.Migrations
{
    public partial class CarGearBoxYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDamage_CarDamagePart_CarDamagePartId",
                table: "CarDamage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDamage_CarDamageType_CarDamageTypeId",
                table: "CarDamage");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDamage_Cars_CarId",
                table: "CarDamage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDamageType",
                table: "CarDamageType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDamagePart",
                table: "CarDamagePart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDamage",
                table: "CarDamage");

            migrationBuilder.RenameTable(
                name: "CarDamageType",
                newName: "CarDamageTypes");

            migrationBuilder.RenameTable(
                name: "CarDamagePart",
                newName: "CarDamageParts");

            migrationBuilder.RenameTable(
                name: "CarDamage",
                newName: "CarDamages");

            migrationBuilder.RenameIndex(
                name: "IX_CarDamage_CarId",
                table: "CarDamages",
                newName: "IX_CarDamages_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDamage_CarDamageTypeId",
                table: "CarDamages",
                newName: "IX_CarDamages_CarDamageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDamage_CarDamagePartId",
                table: "CarDamages",
                newName: "IX_CarDamages_CarDamagePartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDamageTypes",
                table: "CarDamageTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDamageParts",
                table: "CarDamageParts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDamages",
                table: "CarDamages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamages_CarDamageParts_CarDamagePartId",
                table: "CarDamages",
                column: "CarDamagePartId",
                principalTable: "CarDamageParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamages_CarDamageTypes_CarDamageTypeId",
                table: "CarDamages",
                column: "CarDamageTypeId",
                principalTable: "CarDamageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamages_Cars_CarId",
                table: "CarDamages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDamages_CarDamageParts_CarDamagePartId",
                table: "CarDamages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDamages_CarDamageTypes_CarDamageTypeId",
                table: "CarDamages");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDamages_Cars_CarId",
                table: "CarDamages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDamageTypes",
                table: "CarDamageTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDamages",
                table: "CarDamages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDamageParts",
                table: "CarDamageParts");

            migrationBuilder.RenameTable(
                name: "CarDamageTypes",
                newName: "CarDamageType");

            migrationBuilder.RenameTable(
                name: "CarDamages",
                newName: "CarDamage");

            migrationBuilder.RenameTable(
                name: "CarDamageParts",
                newName: "CarDamagePart");

            migrationBuilder.RenameIndex(
                name: "IX_CarDamages_CarId",
                table: "CarDamage",
                newName: "IX_CarDamage_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDamages_CarDamageTypeId",
                table: "CarDamage",
                newName: "IX_CarDamage_CarDamageTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDamages_CarDamagePartId",
                table: "CarDamage",
                newName: "IX_CarDamage_CarDamagePartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDamageType",
                table: "CarDamageType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDamage",
                table: "CarDamage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDamagePart",
                table: "CarDamagePart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamage_CarDamagePart_CarDamagePartId",
                table: "CarDamage",
                column: "CarDamagePartId",
                principalTable: "CarDamagePart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamage_CarDamageType_CarDamageTypeId",
                table: "CarDamage",
                column: "CarDamageTypeId",
                principalTable: "CarDamageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDamage_Cars_CarId",
                table: "CarDamage",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
