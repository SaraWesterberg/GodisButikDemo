using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Candymania.Migrations
{
    /// <inheritdoc />
    public partial class addedProdId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_categoryId",
                table: "Admins",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_productId",
                table: "Admins",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Categories_categoryId",
                table: "Admins",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Products_productId",
                table: "Admins",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Categories_categoryId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Products_productId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_categoryId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_productId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Admins");
        }
    }
}
