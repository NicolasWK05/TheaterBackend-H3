using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ScreenNavigationProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screens_Theaters_TheaterId",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "PremiumSeatRows",
                table: "Screens");

            migrationBuilder.CreateTable(
                name: "PremiumSeatRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumSeatRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PremiumSeatRow_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumSeatRow_ScreenId",
                table: "PremiumSeatRow",
                column: "ScreenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_Theaters_TheaterId",
                table: "Screens",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screens_Theaters_TheaterId",
                table: "Screens");

            migrationBuilder.DropTable(
                name: "PremiumSeatRow");

            migrationBuilder.AddColumn<string>(
                name: "PremiumSeatRows",
                table: "Screens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_Theaters_TheaterId",
                table: "Screens",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
