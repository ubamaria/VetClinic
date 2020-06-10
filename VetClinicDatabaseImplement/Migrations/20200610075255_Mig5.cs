using Microsoft.EntityFrameworkCore.Migrations;

namespace VetClinicDatabaseImplement.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Pets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ClientFIO",
                table: "ClientPets",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPets_ClientId",
                table: "ClientPets",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPets_Clients_ClientId",
                table: "ClientPets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPets_Clients_ClientId",
                table: "ClientPets");

            migrationBuilder.DropIndex(
                name: "IX_ClientPets_ClientId",
                table: "ClientPets");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Pets");

            migrationBuilder.AlterColumn<string>(
                name: "ClientFIO",
                table: "ClientPets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
