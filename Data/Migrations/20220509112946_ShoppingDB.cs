using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Data.Migrations
{
    public partial class ShoppingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matrial",
                columns: table => new
                {
                    MatrialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Part = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrial", x => x.MatrialID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialItem",
                columns: table => new
                {
                    MaterialItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ItemType = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false),
                    MatrialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialItem", x => x.MaterialItemID);
                    table.ForeignKey(
                        name: "FK_MaterialItem_Matrial_MatrialID",
                        column: x => x.MatrialID,
                        principalTable: "Matrial",
                        principalColumn: "MatrialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialItem_MatrialID",
                table: "MaterialItem",
                column: "MatrialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialItem");

            migrationBuilder.DropTable(
                name: "Matrial");
        }
    }
}
