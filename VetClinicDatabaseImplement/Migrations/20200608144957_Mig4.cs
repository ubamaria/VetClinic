using Microsoft.EntityFrameworkCore.Migrations;

namespace VetClinicDatabaseImplement.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientPets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: false),
                    ClientFIO = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPets_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPets_PetId",
                table: "ClientPets",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientPets");
        }
    }
}
